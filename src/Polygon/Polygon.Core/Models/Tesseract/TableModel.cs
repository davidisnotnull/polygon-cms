using System.Collections.Generic;

namespace Polygon.Core.Models.Tesseract
{
    /// <summary>
    /// 
    /// </summary>
    public class TableModel
    {
        public List<string> Header { get; set; }
        
        public List<string[]> Rows { get; set; } 

        public int ColumnCount { get; set; }
        
        public int TotalNumberOfRows { get; set; }
    }
}
