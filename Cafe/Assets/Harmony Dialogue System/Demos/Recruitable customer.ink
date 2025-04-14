// Recruitable customer

Hello! I'd like to order. May I come in?#speaker:Customer
please? #speaker:Customer
+ [Yes! Welcome to the Cafe.] -> LetIn
+ [No, you look infected.] -> MaybeInfected
   
    
    
    
=== MaybeInfected ===
  What!! I'm not infected.#speaker:Customer
Let me make sure.#speaker:player
Where do you want to examine?#speaker:player
+ [Arms]#speaker:Player
    You look at their arms and find nothing#speaker:player
    -> NotInfected
+ [Legs] #speaker:Player
    You look at their legs and find nothing#speaker:player
    -> NotInfected
+ [Neck] #speaker:Player
    You look at their neck and find nothing#speaker:player
    -> NotInfected
    
    
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


