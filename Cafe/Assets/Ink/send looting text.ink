"You wanted to talk?" #speaker:Customer

+ ["Yeah. I need eyes on the streets. Think you're ready to head out?"] -> offer_mission
 
 + ["How are you holding up?"] -> check_in
  
  === check_in ===
  They shrug. #speaker:Customer

"I'm breathing. Better than yesterday." #speaker:Customer

+ ["Good. Because I’ve got something I need you to do."] -> offer_mission
  
  + ["Alright. Rest for now."]#speaker:Player #send_out: no
  
   -> END
   
   === offer_mission ===
   
They straighten up a bit, nodding.

"What do you need?" #speaker:Customer

+ ["Supplies, info—whatever you can find. Just don’t get killed."] -> accept_or_pushback
 
 === accept_or_pushback ===
 The survivor smirks faintly.

"Got it. Streets are quietest at dusk. I’ll head out then."#speaker:Customer

"Thanks. Watch yourself out there."#speaker:Player #send_out: yes

 -> END