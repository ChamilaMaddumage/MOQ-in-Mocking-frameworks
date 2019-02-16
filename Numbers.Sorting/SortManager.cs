using System;
using System.Collections.Generic;
using System.Text;

namespace Numbers.Sorting
{
    public class SortManager : ISortManager
    {
        private readonly IFileManager _fileManager;
        public SortManager(IFileManager fileManager)
        {
            this._fileManager = fileManager;
        }

        public List<int> Sort(string fileName)
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    throw new ArgumentOutOfRangeException(nameof(fileName), "number list is empty.");
                }
                var numbers = _fileManager.ReadCsvFile(fileName);

                return InnerSort(GetNumberList(numbers));
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private List<int> GetNumberList(IList<string> numbers)
        {
            var numberList = new List<int>();

            foreach (var numberString in numbers)
            {
                int numberValue;
                bool success = int.TryParse(numberString, out numberValue);
                if (!success) continue;

                numberList.Add(numberValue);
            }

            return numberList;
        }

        private List<int> InnerSort(List<int> numberList)
        {
            numberList.Sort();

            return numberList;
        }
    }
}
