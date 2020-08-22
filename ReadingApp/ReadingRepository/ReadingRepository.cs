using System;
using System.Collections.Generic;
using System.Text;
using ReadingDB;
using System.Linq;

namespace ReadingRepository
{
    public class ReadingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int Page { get; set; }
        public string Notes { get; set; }
        public System.DateTime ModifiedDate { get; set; }
    }

    public class ReadingRepository
    {
        public ReadingModel Add(ReadingModel readingModel)
        {
            var readingDb = ToDbModel(readingModel);

            DatabaseManager.Instance.Reading.Add(readingDb);
            DatabaseManager.Instance.SaveChanges();

            readingModel = new ReadingModel
            {
                Page = readingDb.ReadingPage,
                ModifiedDate = readingDb.ReadingModifiedDate,
                Author = readingDb.ReadingAuthor,
                Id = readingDb.ReadingId,
                Title = readingDb.ReadingTitle,
                Notes = readingDb.ReadingNotes,
                Type = readingDb.ReadingType
            };
            return readingModel;
        }

        public List<ReadingModel> GetAll()
        {
            // Use .Select() to map the database contacts to ContactModel
            var items = DatabaseManager.Instance.Reading
              .Select(t => new ReadingModel
              {
                  Page = t.ReadingPage,
                  ModifiedDate = t.ReadingModifiedDate,
                  Author = t.ReadingAuthor,
                  Id = t.ReadingId,
                  Title = t.ReadingTitle,
                  Notes = t.ReadingNotes,
                  Type = t.ReadingType,
              }).ToList();

            return items;
        }

        public bool Update(ReadingModel readingModel)
        {
            var original = DatabaseManager.Instance.Reading.Find(readingModel.Id);

            if (original != null)
            {
                DatabaseManager.Instance.Entry(original).CurrentValues.SetValues(ToDbModel(readingModel));
                DatabaseManager.Instance.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Remove(int readingId)
        {
            var items = DatabaseManager.Instance.Reading
                                .Where(t => t.ReadingId == readingId);

            if (items.Count() == 0)
            {
                return false;
            }

            DatabaseManager.Instance.Reading.Remove(items.First());
            DatabaseManager.Instance.SaveChanges();

            return true;
        }

        private Reading ToDbModel(ReadingModel readingModel)
        {
            var readingDb = new Reading
            {
                ReadingPage = readingModel.Page,
                ReadingModifiedDate = readingModel.ModifiedDate,
                ReadingAuthor = readingModel.Author,
                ReadingId = readingModel.Id,
                ReadingTitle = readingModel.Title,
                ReadingNotes = readingModel.Notes,
                ReadingType = readingModel.Type,
            };

            return readingDb;
        }
    }
}
