//Dialogue Demo
//callback()
VAR speakerName = "NPCDemo"
VAR finshedDialogue = false
EXTERNAL callback()
{finshedDialogue: ->CompleteDialogue|-> mainDialogue}
=== mainDialogue === 
Question Here! 問題顯示：   #F1
 * [option1 選擇1 ]
    feedback 1 回應1~ #F2
    -> noOption
 * [option2 選擇2]
     -> secondDialogue

=== secondDialogue ===
feedback 2 回應2 
Question Here! 問題顯示：#F2a
 * [option1 選擇1 ]
    feedback 2-1 回應 2-1  #F3
    -> yesOption 
 * [option2 選擇2]
     feedback 2-2 回應 2-2 #F3a
    -> noOption 

=== noOption ===
~  finshedDialogue = false
->DONE

=== yesOption === 
~ finshedDialogue = true 
->DONE
->END

=== CompleteDialogue ===
feedback 3 回應 3 #F4
-> END