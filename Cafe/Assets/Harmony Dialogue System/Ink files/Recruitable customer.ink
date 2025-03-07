// Recruitable customer

Hello! I'd like to order. May I come in?#speaker:Customer
* Yes! Welcome to the Cafe.#speaker:Player
    Thank you!#speaker:Customer
* No, you look infected.#speaker:Player
    What!! I'm not infected.#speaker:Customer
    -> MaybeInfected
    
    
=== MaybeInfected ===
Let me make sure.#speaker:Player
Where do you want to examine?#speaker:Player
* Arms#speaker:Player
    You look at their arms and find nothing#speaker:Player
    -> NotInfected
* Legs#speaker:Player
    You look at their legs and find nothing#speaker:Player
    -> NotInfected
* Neck#speaker:Player
    You look at their neck and find nothing#speaker:Player
    -> NotInfected
    
    
=== NotInfected ===
I did not find anything. Should we let them in?#speaker:Player
They could be hiding it.#speaker:Player
* I'll let them in#speaker:Player
    You may come in#speaker:Player
    -> END
* Let's play it safe#speaker:Player
    I dont trust you. Leave#speaker:Player
    -> END



