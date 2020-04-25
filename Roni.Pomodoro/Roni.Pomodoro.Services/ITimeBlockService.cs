using System;
using System.Collections.Generic;
using Roni.Pomodoro.Shared;

namespace Roni.Pomodoro.Services
{
    public interface ITimeBlockService
    {
        IEnumerable<TimeBlock> GetTimeBlocks(TimeBlockCategory category, Guid userId);
        IEnumerable<TimeBlock> GetTimeBlocks(DateTime beginDate, DateTime endDate, Guid userId);
        void AddTimeBlock(TimeBlock timeBlock);
        void AddTimeBlocks(IEnumerable<TimeBlock> timeBlocks);
        void DeleteTimeBlock(TimeBlock timeBlock);
        void DeleteTimeBlock(IEnumerable<TimeBlock> timeBlocks);
    }
}