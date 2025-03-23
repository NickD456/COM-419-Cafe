// Recruitable customer

Hello! I'd like to order. May I come in?#speaker:Customer
please? #speaker:Customer
+ [Yes! Welcome to the Cafe.]
    -> LetIn
+ [No, you look infected.] 
    What!! I'm not infected.#speaker:Customer
    -> MaybeInfected
    
    
=== MaybeInfected ===
Let me make sure.#speaker:Player
Where do you want to examine?#speaker:Player
+ [Arms]#speaker:Player
    You look at their arms and find nothing#speaker:Player
    -> NotInfected
+ [Legs] #speaker:Player
    You look at their legs and find nothing#speaker:Player
    -> NotInfected
+ [Neck] #speaker:Player
    You look at their neck and find nothing#speaker:Player
    -> NotInfected
    
    
=== NotInfected ===
I did not find anything. Should we let them in?#speaker:Player
They could be hiding it.#speaker:Player
+ [I'll let them in ] #speaker:Player
    -> LetIn
+ [Let's play it safe ] #speaker:Player
    I dont trust you. Leave#speaker:Player
    -> END
    
=== LetIn ===
You may come in#speaker:Player #enter:Yes
Thank You!#speaker:Customer
-> END


