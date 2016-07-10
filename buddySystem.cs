using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;

namespace BuddySystem_Space {

  // our block has following class members
	class Block{
    // set the getter and setter for each Block method
		public string p_Name{
			get;
			set;
		}

		public int t_Size{
			get;
			set;
		}

		public bool is_Free{
			get;
			set;
		}
	}

	class BuddySystem_Class{

		public static void memory_Declaration(Block[] remaining_Blocks, int chunk_Size, string process_Name){
			
			for (int index=0; index < remaining_Blocks.Length; index++){
				remaining_Blocks[index] = new Block();
				remaining_Blocks[index].p_Name = process_Name;
				remaining_Blocks[index].t_Size = chunk_Size;
				remaining_Blocks[index].is_Free = true;
			}
		}

		static void Main(string []args){
			String Result = "\0"; 
			Console.WriteLine("What should be the Size of our Buddy System ? (Must be Integer)");

			int buddy_System_Max_Mem_Size;
			Result = Console.ReadLine();
			while(!Int32.TryParse(Result, out buddy_System_Max_Mem_Size))
			{
			   Console.WriteLine("Not a valid number, try again.");
			   Result = Console.ReadLine();
			}

			Console.WriteLine("What should be the min chunk size ? (Must be Integer)");
			int chunk_Size;
			Result = Console.ReadLine();
			while(!Int32.TryParse(Result, out chunk_Size))
			{
			   Console.WriteLine("Not a valid number, try again.");
			   Result = Console.ReadLine();
			}

      		// we will create an array of blocks of size = memory size upper bound / memory size lower bound (chunk size in our case)
			int block_Array_Size = buddy_System_Max_Mem_Size / chunk_Size;
      		// an array of blocks initially all are free
			Block[] remaining_Blocks = new Block[block_Array_Size];

      		// fill our newly created array with empty processes and marking it available to use
			String process_Name = "\0";
			memory_Declaration(remaining_Blocks, chunk_Size, process_Name);
			// now we create a list of our newly created empty block array.
			List<Block> blocks_List = new List<Block>();
		}

	}
}
