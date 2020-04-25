using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Roni.Pomodoro.Persistence;
using Roni.Pomodoro.Persistence.Entities;
using Roni.Pomodoro.Shared;

namespace Roni.Pomodoro.Services
{
    public class TimeBlockService : ITimeBlockService
    {
        private readonly IRepository<TaskBlock> _taskBlockRepository;
        private readonly IRepository<TaskBlockCategory> _taskBlockCategoryRepository;
        private readonly IMapper _mapper;

        public TimeBlockService(IRepository<TaskBlock> taskBlockRepository, IRepository<TaskBlockCategory> taskBlockCategoryRepository, IMapper mapper)
        {
            _taskBlockRepository = taskBlockRepository;
            _taskBlockCategoryRepository = taskBlockCategoryRepository;

            _mapper = mapper;
        }

        public IEnumerable<TimeBlock> GetTimeBlocks(TimeBlockCategory category, Guid userId)
        {
            var taskBlocks = _taskBlockRepository.Get().Where(x => x.TaskBlockCategory.Description == category.Description && x.UserId == userId);
            return _mapper.Map<IEnumerable<TaskBlock>, IEnumerable<TimeBlock>>(taskBlocks);
        }

        public IEnumerable<TimeBlock> GetTimeBlocks(DateTime beginDate, DateTime endDate, Guid userId)
        {
            var taskBlocks = _taskBlockRepository.Get().Where(x => x.StartDate == beginDate && x.StopDate == endDate
                                                                   && x.UserId == userId);

            return _mapper.Map<IEnumerable<TaskBlock>, IEnumerable<TimeBlock>>(taskBlocks);
        }

        public void AddTimeBlock(TimeBlock timeBlock)
        {
            var taskBlock = _mapper.Map<TimeBlock, TaskBlock>(timeBlock);
            _taskBlockRepository.Insert(taskBlock);
        }

        public void AddTimeBlocks(IEnumerable<TimeBlock> timeBlocks)
        {
            var taskBlocks = _mapper.Map<IEnumerable<TimeBlock>, IEnumerable<TaskBlock>>(timeBlocks);
            _taskBlockRepository.Insert(taskBlocks);
        }

        public void DeleteTimeBlock(TimeBlock timeBlock)
        {
            var taskBlock = _mapper.Map<TimeBlock, TaskBlock>(timeBlock);
            _taskBlockRepository.Delete(taskBlock);
        }

        public void DeleteTimeBlock(IEnumerable<TimeBlock> timeBlocks)
        {
            var taskBlocks = _mapper.Map<IEnumerable<TimeBlock>, IEnumerable<TaskBlock>>(timeBlocks);
            _taskBlockRepository.Delete(taskBlocks);
        }


    }
}
