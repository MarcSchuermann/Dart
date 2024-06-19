// -----------------------------------------------------------------------
// <copyright file="Player.cs" company="Marc Schürmann">
//     Copyright (c) Marc Schürmann. All Rights Reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using Schuermann.Dart.Core.Thrown;
using Schuermann.Dart.Core.UndoRedo.Interfaces;
using Schuermann.Darts.GameCore.UndoRedo.Impl.Actions;

namespace Schuermann.Dart.Core.Game
{
   /// <summary>The Player.</summary>
   public class Player : IPlayer, IUndoRedo, IEquatable<IPlayer>
   {
      #region Private Fields

      private readonly bool doubleIn;

      private readonly bool doubleOut;

      #endregion Private Fields

      #region Public Constructors

      /// <summary>Initializes a new instance of the <see cref="Player" /> class.</summary>
      /// <param name="name">The name.</param>
      /// <param name="startPoints"></param>
      public Player(string name, uint startPoints) : this(name, startPoints, new List<IDartThrow>())
      {
      }

      /// <summary>Initializes a new instance of the <see cref="Player" /> class.</summary>
      /// <param name="name">The name.</param>
      /// <param name="startPoints">The start points.</param>
      /// <param name="doubleIn">if set to <c>true</c> [double in].</param>
      /// <param name="doubleOut">if set to <c>true</c> [double out].</param>
      public Player(string name, uint startPoints, bool doubleIn, bool doubleOut) : this(name, startPoints, new List<IDartThrow>())
      {
         this.doubleIn = doubleIn;
         this.doubleOut = doubleOut;
      }

      #endregion Public Constructors

      #region Internal Constructors

      /// <summary>Initializes a new instance of the <see cref="Player" /> class.</summary>
      /// <param name="name">The name.</param>
      /// <param name="startPoints">The start points.</param>
      /// <param name="throwHistory">The throw history.</param>
      internal Player(string name, uint startPoints, IList<IDartThrow> throwHistory)
      {
         Name = name;
         StartPoints = startPoints;
         ThrowHistory = throwHistory;
         Id = Guid.NewGuid();
      }

      #endregion Internal Constructors

      #region Public Properties

      /// <summary>Gets or sets the current score.</summary>
      /// <value>The current score.</value>
      public uint CurrentScore => CalculateRoundAndDartCount().Item3;

      /// <summary>Gets or sets the dart count per round.</summary>
      /// <value>The dart count per round.</value>
      public int DartCountThisRound => CalculateRoundAndDartCount().Item2;

      /// <summary>Gets the identifier.</summary>
      /// <value>The identifier.</value>
      public Guid Id { get; }

      /// <summary>Gets or sets the name.</summary>
      /// <value>The name.</value>
      public string Name { get; }

      /// <summary>Gets or sets the points this round.</summary>
      /// <value>The points this round.</value>
      public int PointsThisRound
      {
         get
         {
            switch (DartCountThisRound)
            {
               case 0:
                  return 0;

               case 1:
                  return ThrowHistory.Last().Points;

               case 2:
                  return ThrowHistory.Last().Points + ThrowHistory[ThrowHistory.Count - 2].Points;

               default:
                  return -1;
            }
         }
      }

      /// <summary>Gets or sets the round.</summary>
      /// <value>The round.</value>
      public int Round => CalculateRoundAndDartCount().Item1;

      /// <summary>Gets the start points.</summary>
      /// <value>The start points.</value>
      public uint StartPoints { get; }

      /// <summary>Gets or sets the throw history.</summary>
      /// <value>The throw history.</value>
      public IList<IDartThrow> ThrowHistory { get; internal set; }

      #endregion Public Properties

      #region Private Properties

      /// <summary>Gets the redo stack.</summary>
      /// <value>The redo stack.</value>
      private Stack<IUndoRedo> RedoStack { get; } = new();

      /// <summary>Gets the undo stack.</summary>
      /// <value>The undo stack.</value>
      private Stack<IUndoRedo> UndoStack { get; } = new();

      #endregion Private Properties

      #region Public Methods

      /// <summary>Creates a new object that is a copy of the current instance.</summary>
      /// <returns>A new object that is a copy of this instance.</returns>
      public object Clone()
      {
         var history = new List<IDartThrow>();
         foreach (var item in ThrowHistory)
         {
            history.Add(item.Clone() as IDartThrow);
         }
         return new Player(Name?.Clone()?.ToString(), StartPoints) { ThrowHistory = history };
      }

      /// <summary>
      ///    Indicates whether the current object is equal to another object of the same type.
      /// </summary>
      /// <param name="other">An object to compare with this object.</param>
      /// <returns>
      ///    <see langword="true" /> if the current object is equal to the <paramref name="other"
      ///    /> parameter; otherwise, <see langword="false" />.
      /// </returns>
      public bool Equals(IPlayer other)
      {
         if (other == null)
            return false;

         return string.Equals(Name, other.Name, StringComparison.Ordinal) && ThrowHistory.SequenceEqual(other.ThrowHistory);
      }

      /// <summary>
      ///    Determines whether the specified <see cref="object" />, is equal to this
      ///    instance.
      /// </summary>
      /// <param name="obj">
      ///    The <see cref="object" /> to compare with this instance.
      /// </param>
      /// <returns>
      ///    <c>true</c> if the specified <see cref="object" /> is equal to this instance;
      ///    otherwise, <c>false</c>.
      /// </returns>
      public override bool Equals(object obj)
      {
         if (!(obj is IPlayer player))
            return false;

         return Equals(player);
      }

      /// <summary>Returns a hash code for this instance.</summary>
      /// <returns>
      ///    A hash code for this instance, suitable for use in hashing algorithms and data
      ///    structures like a hash table.
      /// </returns>
      public override int GetHashCode()
      {
         return Name.GetHashCode(StringComparison.Ordinal) ^ ThrowHistory.GetHashCode();
      }

      /// <summary>Redoes this instance.</summary>
      public void Redo()
      {
         if (RedoStack.Count == 0)
            return;

         var action = RedoStack.Pop();
         action.Redo();
      }

      /// <summary>Throws the specified dart throw.</summary>
      /// <param name="dartThrow">The dart throw.</param>
      public void Thrown(IDartThrow dartThrow)
      {
         if (dartThrow == null)
            return;

         ThrowHistory.Add(dartThrow);

         UndoStack.Push(new ThrownAction(this, dartThrow));
      }

      /// <summary>Returns a <see cref="string" /> that represents this instance.</summary>
      /// <returns>A <see cref="string" /> that represents this instance.</returns>
      public override string ToString()
      {
         return Name;
      }

      /// <summary>Undoes this instance.</summary>
      public void Undo()
      {
         if (UndoStack.Count == 0)
            return;

         var action = UndoStack.Pop();
         action.Undo();
         RedoStack.Push(action);
      }

      #endregion Public Methods

      #region Private Methods

      private Tuple<int, int, uint> CalculateRoundAndDartCount()
      {
         var roundCounter = 1;
         var dartPerRoundCounter = 0;
         var pointsAtThisMoment = StartPoints;
         var hasThownDoubleField = false;

         foreach (var thrown in ThrowHistory)
         {
            dartPerRoundCounter++;

            // Haendle doubleIn
            if (doubleIn)
            {
               if (!hasThownDoubleField && thrown.DartBoardQuantifier == DartBoardQuantifier.Double)
                  hasThownDoubleField = true;

               if (doubleIn && !hasThownDoubleField)
               {
                  if (dartPerRoundCounter >= 3)
                  {
                     dartPerRoundCounter = 0;
                     roundCounter++;
                  }
                  continue;
               }
            }

            // Handle double out
            if (doubleOut)
            {
               if (pointsAtThisMoment - thrown.Points == 1)
               {
                  dartPerRoundCounter = 0;
                  roundCounter++;
                  continue;
               }

               if (pointsAtThisMoment - thrown.Points == 0 && thrown.DartBoardQuantifier != DartBoardQuantifier.Double)
               {
                  dartPerRoundCounter = 0;
                  roundCounter++;
                  continue;
               }
            }

            // Throw result would be lower than 0
            if (pointsAtThisMoment - thrown.Points < 0)
            {
               dartPerRoundCounter = 0;
               roundCounter++;
               continue;
            }

            // Calculate new points
            pointsAtThisMoment -= (uint)thrown.Points;

            // Zero points --> finish
            if (pointsAtThisMoment == 0)
               continue;

            // 3 darts per round thrown
            if (dartPerRoundCounter >= 3)
            {
               dartPerRoundCounter = 0;
               roundCounter++;
            }
         }

         return new Tuple<int, int, uint>(roundCounter, dartPerRoundCounter, pointsAtThisMoment);
      }

      #endregion Private Methods
   }
}