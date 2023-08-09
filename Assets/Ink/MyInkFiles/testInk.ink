


->StartKnot

===StartKnot===
The text has been started.
* [...]
    ->END

===LookKnot===
You are looking.
* [Okay]
    ->END
===TalkKnot===
You are talking.
* [Okay]
    ->END

////////////////////////////////////////////////////////////////////////
//                             CHARACTERS                             //
///////////////////////////////////////////////////////////////////////

////////////////////////
//   NPC CHARACTER   //
//////////////////////
//Dialogue
===NPCTalk===
"Hey it's me, your wife."
    * "What?"
- She stares at you. "Not this again."
    ** "Fuck."
-> END

//Look at NPC
===NPCLook===
You remember her, don't you?
* [...]
- Her face seems familiar...
* [...]
-- ... perhaps important.
** [...]
Eh. Probably nothing. You've seen a lot of faces before.
*** [Good point.]
->END

    
////////////////////////
//   QUENTINGTON     //
//////////////////////
//Dialogue
===QuentingtonTalk===
The guy in the shit hat stares at you.
* ...
- "Good day," he chirps from under his hat.
** ["Good day to you, too."] ->END
** ["Your hat's shit, mate!"] ->UpsetQuentington

    //Upset Quentington
    ==UpsetQuentington
    -The man's shoulders shake as he begins to sob...
    * ...
    - ...inconsolably. 
    ** "Oh no."
    -- The corners of his hat jiggle amusingly as he whimpers.
    *** Leave him be ->END



//Look
===QuentingtonLook===
Look at this guy in his shit hat.
 * "Bellend."
->END    
////////////////////////
//   THE BLOCK       //
//////////////////////
===THEBLOCK===
The block stands motionless, pale against the verdant landscape.
* "The fuck is that?"
- I suppose we'll never know.
** "Hmm."
->END

////////////////////////////////////////////////////////////////////////
//                                  ITEMS                             //
///////////////////////////////////////////////////////////////////////
===item_sword==
It's just a sword - nothing special.
* ... ->END
