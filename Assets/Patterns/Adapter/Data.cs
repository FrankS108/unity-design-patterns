using System;

namespace Patterns.Adapter
{
    [Serializable]
    public class Data
    {
        public string Dato1;
        public int Dato2;

        public Data(string dato1, int dato2)
        {
            this.Dato1 = dato1;
            this.Dato2 = dato2;
        }
    }
}


