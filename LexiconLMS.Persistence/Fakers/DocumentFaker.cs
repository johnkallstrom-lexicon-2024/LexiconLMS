using Bogus;

namespace LexiconLMS.Persistence.Fakers
{
    public class DocumentFaker : Faker<Document>
    {
        public DocumentFaker()
        {
            RuleFor(d => d.Name, f => $"Document {f.Commerce.Ean8()}");
            RuleFor(d => d.Description, f => f.Lorem.Paragraphs());
            RuleFor(d => d.UploadTime, DateTime.Now);
            RuleFor(d => d.Created, DateTime.Now);
        }
    }
}
