using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace Buddy_system_space {
  
  // our block has following class members
  class Block{
    // set the getter and setter for each Block method
    public string p_name{
      get;
      set;
    }

    public int size{
      get;
      set;
    }

    public bool is_free{
      get;
      set;
    }
  }

  class Buddy_system_class{
    static void Main(string []args){
      Console.WriteLine("What should be the Size of our Buddy System ? (Must be Integer)");
      int buddy_system_max_mem_size = Convert.ToInt32(Console.ReadLine());
      Console.WriteLine("What should be the min chunk size ? (Must be Integer)");
      int chunk_size = Convert.ToInt32(Console.ReadLine());
    }

  }
}
