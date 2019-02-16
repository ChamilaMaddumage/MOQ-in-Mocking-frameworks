using System;
using System.Collections.Generic;
using System.Text;

namespace Numbers.Sorting
{
    public interface IFileManager
    {
        List<string> ReadCsvFile(string filePath);

    }
}
