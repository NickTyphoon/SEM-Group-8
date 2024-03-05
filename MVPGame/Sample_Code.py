import math

#----------------------------------------------------------------------

def double_jump(start_height, jump_height):
    
    end_height = round(start_height + jump_height)
    
    return end_height

#------------------------------------------------------------------

def main():
    
    result = double_jump(5, 7)
 
#------------------------------------------------------------------ 
   
    print(f"Result: {result}")
    print("Power-up Unlocked!")
    
    
if __name__ == "__main__":
    main()
    