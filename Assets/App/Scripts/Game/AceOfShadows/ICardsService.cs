using System;
using UniRx;

namespace App.AceOfShadows
{
    public interface ICardsService
    {
        /// <summary>
        /// All cards have been moved
        /// </summary>
        IObservable<Unit> OnMovingComplete { get; }
    }
}