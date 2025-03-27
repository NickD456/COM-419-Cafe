// Recruitable customer

A lone survivor stands outside, clutching a wound on their arm.#speaker:Customer

+ ["Who are you?"]
   -> Introduction
+ ["Move along. I don’t take in strays."] 
   -> Reject
    
    
=== Introduction ===
The survivor exhales sharply, "I was with a group, but we got attacked. I got separated. I just need a place to stay." #speaker:Customer

+ ["You’re wounded. How bad is it?"]#speaker:Player
    -> WoundCheck
    
+ ["Why should I trust you?"] #speaker:Player
     -> TrustCheck

    
    
=== WoundCheck ===
"It's not a bite. Just a scratch from barbed wire when I ran."#speaker:Customer
You see blood slowly roll down their arm.#speaker:player
 -> TrustCheck
    
=== TrustCheck ===
"I can fight. Let me stay, and I’ll help defend this place at night."#speaker:Customer

"If you turn me away, I’ll probably die out here."#speaker:Customer
  -> Decision
  
  === Decision ===
  + ["Alright, you can stay. But if you cause trouble, you're out."]#speaker:player 
  "Thank you... I swear, you won’t regret this. I just—I just need a chance to survive."#speaker:Customer #recruit: yes
  
  -> END
  + ["I’m sorry. I have to think about my own survival first."]#speaker:player 
  -> Reject
  
  === Reject ===
  "Seriously? After everything I’ve been through, you’re just throwing me back out there? Fine. I’ll remember this when your luck runs out."#speaker:Customer #recruit: no
    -> END
  
  