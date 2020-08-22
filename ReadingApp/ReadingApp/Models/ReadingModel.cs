using System;
using System.Collections.Generic;
using System.Text;

namespace ReadingApp.Models
{
    public class ReadingModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Type { get; set; }
        public int Page { get; set; }
        public string Notes { get; set; }
        public DateTime ModifiedDate { get; set; }

        public ReadingModel Clone() 
        {
            return (ReadingModel)MemberwiseClone();
        }

        public ReadingRepository.ReadingModel ToRepositoryModel()
        {
            var repositoryModel = new ReadingRepository.ReadingModel
            {
                Page = Page,
                ModifiedDate = ModifiedDate,
                Author = Author,
                Id = Id,
                Title = Title,
                Notes = Notes,
                Type = Type
            };

            return repositoryModel;
        }

        public static ReadingModel ToModel(ReadingRepository.ReadingModel respositoryModel)
        {
            var readingModel = new ReadingModel
            {
                Page = respositoryModel.Page,
                ModifiedDate = respositoryModel.ModifiedDate,
                Author = respositoryModel.Author,
                Id = respositoryModel.Id,
                Title = respositoryModel.Title,
                Notes = respositoryModel.Notes,
                Type = respositoryModel.Type
            };

            return readingModel;
        }

        public bool compareTitleText(string searchText)
        {
            if(searchText.Length > Title.Length) 
            {
                return false;
            }

            searchText = searchText.ToLower();
            string myTitle = Title.ToLower();

            for (int i = 0; i < searchText.Length; i++) 
            {
                if(searchText[i] != myTitle[i]) 
                {
                    return false;
                }
            }
            return true;
        }

        public bool compareAuthorText(string searchText)
        {
            if (searchText.Length > Author.Length)
            {
                return false;
            }

            searchText = searchText.ToLower();
            string myAuthor = Author.ToLower();

            for (int i = 0; i < searchText.Length; i++)
            {
                if (searchText[i] != myAuthor[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
