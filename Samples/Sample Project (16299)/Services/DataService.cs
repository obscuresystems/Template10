﻿using Bogus;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Services
{
    public interface IDataService
    {
        Task InitializeAsync();
        IEnumerable<DataItem> GetItems();
        IEnumerable<string> GetSuggestions(string text, int count);
        IEnumerable<DataItem> Search(string text);
    }

    public class DataService : IDataService
    {
        public async Task InitializeAsync()
        {
            await Task.CompletedTask;
        }

        public IEnumerable<DataItem> GetItems()
        {
            Randomizer.Seed = new Random(8675309);

            var images = new[] { "Apples", "Bananas", "Blackberries", "Cabbage", "Carrots", "Cauliflower", "Cherries", "Coconuts", "EggPlant", "Figs", "Ginger", "Grapefruits", "Grapes", "GreenBeans", "Kale", "Kiwis", "Lemons", "Nectarines", "Onions", "Oranges", "Peaches", "Pears", "Plumbs", "Raspberries", "Strawberries", "Tomatoes", "Zuchinnis" };

            var items = new Faker<DataItem>()
                .RuleFor(i => i.Index, f => ++f.IndexVariable)
                .RuleFor(i => i.Title, f => f.Commerce.ProductName())
                .RuleFor(i => i.Text, f => f.Lorem.Sentences(3))
                .RuleFor(i => i.Image, f => $"ms-appx:///Images/{f.PickRandom(images)}.jpg");
            return items.Generate(150);
        }

        public IEnumerable<string> GetSuggestions(string text, int count)
        {
            return GetItems()
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .OrderBy(x => x.Title)
                .Take(count)
                .Select(x => x.Title);
        }

        public IEnumerable<DataItem> Search(string text)
        {
            return GetItems()
                .Where(x => x.Title.ToLower().Contains(text.ToLower()))
                .OrderBy(x => x.Title);
        }
    }
}
