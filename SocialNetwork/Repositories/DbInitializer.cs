using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbContext.Entities;
using DbContext.Entities.AspNet;
using Repositories.Implementations;
using Repositories.Implementations.AspNet;
using Repositories.Interfaces;

namespace DbContext
{
    public static class DbInitializer
    {
        private static readonly AppDbContext _appDbContext;
        private static readonly IWorkplacesRepository _workplacesRepository;
        private static readonly AspNetUsersRepository _aspNetUsersRepository;

        static DbInitializer()
        {
            _appDbContext = AppDbContext.Create();
            _workplacesRepository = new WorkplacesRepository(AppDbContext.Create());
            _aspNetUsersRepository = new AspNetUsersRepository(AppDbContext.Create());
        }

        public static async Task Init()
        {
            await FillWorkplaces();
        }

        private static async Task FillWorkplaces()
        {
            var workplaces = await _workplacesRepository.GetItemsAsync();

            if (workplaces.Any())
                return;

            await _workplacesRepository.AddItemAsync(new Workplace
            {
                Description = "Some text 11111",
                Title = "Workplace1"
            });

            await _workplacesRepository.AddItemAsync(new Workplace
            {
                Description = "Some text 22222",
                Title = "Workplace2"
            });

            await _workplacesRepository.AddItemAsync(new Workplace
            {
                Description = "Some text 333333",
                Title = "Workplace3"
            });

        }
    }
}
