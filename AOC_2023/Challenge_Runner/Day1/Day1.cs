using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_Runner.Day1 {
    public class Day1 {
        string data;

        private void LoadData() {
            data = File.ReadAllText("input.txt");
        }

        public void Run() {
            LoadData();
            Console.Write(data);
        }
    }
}
