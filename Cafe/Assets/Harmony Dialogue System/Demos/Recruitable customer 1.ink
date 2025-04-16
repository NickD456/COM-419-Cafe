// Recruitable customer

Hello! I'd like to order. May I come in?#speaker:Customer
please? #speaker:Customer
+ [Yes! Welcome to the Cafe.] -> LetIn
+ [No, you look infected.] -> MaybeInfected
   
    
    
    
=== MaybeInfected ===
  What!! I'm not infected.#speaker:Customer
Let me make sure.#speaker:player
Where do you want to examine?#speaker:player

+ [Legs] #speaker:Player
    You look at their legs and find nothing#speaker:player
      -> NotInfected
      
    + [Arms]#speaker:Player
    You look at their arms and find a small bite mark#speaker:player
    -> Infected
    
  
+ [Neck] #speaker:Player
    You look at their neck and find nothing#speaker:player
    -> NotInfected
    
   === Infected ===
   That’s... a bite.#speaker:player 
   "Wait, it's not what it looks like! I’ve kept it clean! I’m not turning!"#speaker:Customer  
"Please—just give me a chance."#speaker:Customer  
+ [Let them in anyway] #speaker:player  
    You step aside.#speaker:player  
    If you turn, you're out.#speaker:player  
    Thank you. Seriously.#speaker:Customer #enter:yes  
    -> END  
    
    + [I cant take that risk] #speaker:player  
    I’m sorry. Can’t take the risk.#speaker:player  
    ...Your making a mistake.#speaker:Customer #enter:no  
    -> END
   
   
=== NotInfected ===
I did not find anything. Should we let them in?#speaker:player
They could be hiding it.#speaker:player
+ [I'll let them in ] -> LetIn
+ [Let's play it safe ] #speaker:player
    I dont trust you. Leave#speaker:player 
    How... How could you?#speaker:Customer #enter:no
    -> END
    
=== LetIn ===
You may come in#speaker:player 
Thank You!#speaker:Customer #enter:yes
-> END


