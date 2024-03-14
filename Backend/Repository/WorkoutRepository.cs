﻿using Backend.Models;
using Backend.Repository.Interfaces;

namespace Backend.Repository
{
    public class WorkoutRepository : RepositoryBase<Workout>, IWorkoutRepository
    {
        public WorkoutRepository(ApplicationDataContext dbContext) : base(dbContext)
        {
        }

        public Workout AddWorkout(int userId, Workout workout)
        {
            workout.UserId = userId;
            return Create(workout);
        }

        public IEnumerable<Workout> GetAllWorkouts(int userId)
        {
            return FindByCondition(u => u.Id == userId);
        }
    }
}