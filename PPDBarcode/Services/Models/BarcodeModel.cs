using System;

namespace PPDBarcode.Services
{
    public class BarcodeModel
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public int Size{ get; set; }

        public override string ToString()
        {
            return String.Format("barcode(Name={0};Value={1};Size={2})", Name, Value, Size);
        }
    }
}