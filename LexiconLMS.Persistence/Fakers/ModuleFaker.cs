﻿using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class ModuleFaker : Faker<Module>
    {
        public ModuleFaker()
        {
            RuleFor(m => m.Name, f => $"Module {f.Commerce.Ean8()}");
            RuleFor(m => m.Description, f => f.Lorem.Paragraphs(count: 1));
            RuleFor(m => m.StartDate, DateTime.Now.AddMonths(1).AddDays(14));
            RuleFor(m => m.EndDate, DateTime.Now.AddMonths(3));
            RuleFor(m => m.Created, DateTime.Now);
        }
    }
}
