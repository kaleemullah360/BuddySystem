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

		/*============ initialize the block array i.e whole buddy system memory. ======= */
		public static void memory_Declaration(Block[] remaining_Blocks, int chunk_Size, string process_Name){
			
			for (int index=0; index < remaining_Blocks.Length; index++){
				remaining_Blocks[index] = new Block();
				remaining_Blocks[index].p_Name = process_Name;
				remaining_Blocks[index].t_Size = chunk_Size;
				remaining_Blocks[index].is_Free = true;
			}
		}

		/*============ method to show which block is free and which one is being used by which process. ======= */
		public static void memory_View(List <Block> blocks_List){
			// here we will look for each block and show its status
			foreach (var block in blocks_List){
				if(block.is_Free){
						// display free block memory size
						Console.Write(" Free Memory: " + block.t_Size.ToString() + "KB\n");
					}else{
						// display allocated block memory size
						Console.Write("Process: " + block.p_Name + " Used Memory: " + block.t_Size.ToString() + "KB\n");
					}
			}

			Console.Write("\n");
		}

		/*============ method to search the block which is suitable to hold process requires memory. ======= */
		public static int search_Required_Block(int size, int current_Index, Block[] remaining_Blocks){
			int block_Size = 0;
            for (int index = current_Index; index < remaining_Blocks.Length; index++){
                if (remaining_Blocks[index].is_Free == false){
                    return 0;
                }else{
                    block_Size += remaining_Blocks[index].t_Size;
                    if (block_Size >= size)
                    return index;
                }
            }
            return 0;
		}

		/*============ block allocation in buddy system. ======= */
		public static void assign_Block(string process_Name, int size, Block[] remaining_Blocks){

			for (int index=0; index < remaining_Blocks.Length; index++){
				if (remaining_Blocks[index].is_Free == true && remaining_Blocks[index].t_Size >= size){	
				// process can be fitted into the block
                    remaining_Blocks[index].is_Free = false;
					remaining_Blocks[index].p_Name = process_Name;
                    break;
                }else if (remaining_Blocks[index].is_Free == true && remaining_Blocks[index].t_Size <= size){ 
                // if process can't be fitted into the block the find the block that full fill the requirements
                	int required_Blocak = search_Required_Block(size, index, remaining_Blocks);
                	if(required_Blocak !=0){ // we found that required block
                        for (; index <= required_Blocak; index++){
                            remaining_Blocks[index].is_Free = false;
                            remaining_Blocks[index].p_Name = process_Name;
                        }
                        break;
                    }

                }

			}

		}

        public static void redeem_Block(Block[] remaining_Blocks, List<Block> blocks_List, string process_Name){

            blocks_List.Clear();
            int memory = 0;
            for (int index = 0; index < remaining_Blocks.Length; index++){
                if (remaining_Blocks[index].is_Free == false){
                    if (memory != 0){
                        Block free_Blocks = new Block();
                        free_Blocks.p_Name = process_Name;
                        free_Blocks.is_Free = true;
                        free_Blocks.t_Size = memory;
                        blocks_List.Add(free_Blocks);
                        memory = 0;
                    }
                    Block used_Block = new Block();
                    used_Block.p_Name = remaining_Blocks[index].p_Name;
                    used_Block.t_Size = remaining_Blocks[index].t_Size;
                    used_Block.is_Free = false;
                    blocks_List.Add(used_Block);

                }else{
                    memory += remaining_Blocks[index].t_Size;
                }
            }

            if (memory != 0){
                Block free_Blocks = new Block();
                free_Blocks.p_Name = process_Name;
                free_Blocks.is_Free = true;
                free_Blocks.t_Size = memory;
                blocks_List.Add(free_Blocks);
                memory = 0;
            }
        }

		static void Main(string []args){
			int milliSec = 3500;
			String Result = "\0"; // null
			Console.Write("What should be the Size of our Buddy System ? (Must be Integer)\n");

			int buddy_System_Max_Mem_Size;
			Result = Console.ReadLine();
			while(!Int32.TryParse(Result, out buddy_System_Max_Mem_Size))
			{
			   Console.Write("Not a valid number, try again.\n");
			   Result = Console.ReadLine();
			}

			Console.Write("What should be the min chunk size ? (Must be Integer).\n");
			int chunk_Size;
			Result = Console.ReadLine();
			while(!Int32.TryParse(Result, out chunk_Size))
			{
			   Console.Write("Not a valid number, try again.\n");
			   Result = Console.ReadLine();
			}

      		// we will create an array of blocks of size = memory size upper bound / memory size lower bound (chunk size in our case)
			int block_Array_Size = buddy_System_Max_Mem_Size / chunk_Size;
      		// an array of blocks initially all are free
			Block[] remaining_Blocks = new Block[block_Array_Size];

      		// fill our newly created array with empty processes and marking it available to use
			String process_Name = "\0";	// null
			memory_Declaration(remaining_Blocks, chunk_Size, process_Name);
			// now we create a list of our newly created empty block array.
			List<Block> blocks_List = new List<Block>();
			// create a block and add it to list
			Block one_Block = new Block();
			one_Block.p_Name = process_Name;
			one_Block.t_Size = chunk_Size;
			one_Block.is_Free = true;

			blocks_List.Add(one_Block);
			// view our list to show that the which block is free and which one is in use
			memory_View(blocks_List);

			// we will scrap all the inputs parameters from an input file
			string input_File = "input.txt";
			// if our input file exist and is readable
            using (StreamReader sR = new StreamReader(input_File))
            {	
            	// read the file till null is found
                string param_s;
                while ((param_s = sR.ReadLine()) != null){

            	// each row in the input files contains params as foloows:
            	// | Function name      | Process Name | Memory Required   |
            	// | E/L => Enter/Leave | A => (Name)  | 50 => (KB Memory) |
            	// all params are TAB Separated

                string[] param = param_s.Split('\t');
                    Thread.Sleep(milliSec);

                    if(param[0] == "E" || param[0] == "e"){
                    	// incase of Process Entered Execution state
                    	Console.Write("Process " + param[1] + " Entered. Mem Required: " + param[2] + "KB\n");
                    	// allocate the new process momory
                    	assign_Block(param[1], int.Parse(param[2]), remaining_Blocks);
                    	// merge back freed blocks
                    	redeem_Block(remaining_Blocks, blocks_List, process_Name);
						// view our list to show that the which block is free and which one is in use
						memory_View(blocks_List);
                    }else if(param[0] == "L" || param[0] == "l"){
                    	// incase of Process Leave, then need to free memory

                    }
            	}
            }
		}

	}
}
