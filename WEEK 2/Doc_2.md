# Goals and sprint plan

whos playing what role

## Specifications

1.1 The game design must be age-appropriate for the players; it should be engaging and not contain violent elements.
1.2 The players should find the instructions of the game easy to read and understand.

2.1 The coins will be placed on platforms, which the user needs to jump onto to collect.
2.2 The game instructions should inform the users how to collect the coins: WASD to move up, down, left and right.
2.3 The system should keep track of the number of coins collected by the player.
2.4 The number of coins collected should be visible to the player.

3.1 A pop-up screen should display 10 fragments of code after the player has collected 10 coins.
3.2 The system should allow the players to drag the code fragments into different positions to arrange them into a sequence.

4.1 The background of the pop-up screen will turn red when the sequence of code formed by the user is incorrect.
4.2 The background of the pop-up screen will turn green when the sequence of code formed by the user is correct.

5.1 The system should unlock a new power-up and the pop-up screen should display a success message when the code fragments are arranged correctly.
5.2 The pop-up screen should indicate the name of the power-up. 
5.3 The pop-up screen should indicate the controls for the power-up.
5.4 The game takes the user to the next level, where they must collect 10 coins again.
5.5 The unlocked power-ups should be visible to the user while playing the game.

## Requirements

1. The target users are children aged 11-14 years.
2. The players need to collect fragments of code, represented by coins.
3. The players should learn how to arrange the collected code fragments into a logical line of code.
4. The players should receive feedback about the formed sequence of code.
5. The players should unlock power-ups and advance to succeeding levels.

## User Stories
 - Overall user story
 
   As a player, I want to learn programming through games, so that learning can be more enjoyable and engaging, enhancing motivation and efficiency.
 - Sub-story

   1）As a player, I want my character to be able to collect coins, so that I can increase my score and get rewards (pieces of code).

   2）As a player, I want to collect a suitable number of coins in the game (between 5 and 15 per level), so that the game remains challenging and enjoyable, without being too easy or too difficult.

   3）As a player, I want the game to display a pop-up window with instructions on how to use the collected code blocks after reaching a certain number of them, so that I can learn and understand programming concepts.

   4）As a player, I want to receive feedback after rearranging code snippets, indicating whether they are correct or not, so that I can adjust and learn in a timely manner.

   5）As a player, I want the game to have multiple different platforms to explore, rather than just a single platform, so that it adds variety and enjoyment to the game.

   6）As a player, I want my character to perform basic WASD (left, right, up, down) movements, so that I can control the character's actions and navigate through obstacles smoothly.

   7）As a player, I want my character to have the ability to jump, so that I can better control the character's actions and reach additional platforms.
   
## Personas
 - Name: "Daniel"
 - Age: 12 years old (KS3:11-14)
 - Gender: Male
 - Occupation: Student
 - Interests: Basketball, Anime, E-sports, Video Games
 - Location: United Kingdom
 - Learning Situation: Interested in programming but am a novice with no experience, hopes to learn programming-related -knowledge in a fun and engaging way through platform games.
 - Learning Style: Prefers interactive and hands-on learning, lacks patience for boring theoretical courses.
 - Goals: Cultivating an interest in learning programming, learning the foundational framework knowledge through gaming, gradually deepening understanding of programming, and ultimately creating one's own games or applications.
 - Gaming Habits: Spends approximately 5-8 hours per week playing video games during leisure time, and enjoys playing action-adventure platform games, especially those with challenging levels and reward systems. He is particularly interested in game development within programming, so he hopes to learn programming knowledge through gaming.

## Use Case Diagram

## Activity Diagram

## Low-Fidelity Storyboard

![Low Fid](/Res/MVP%20Storyboard.jpg )

## High-Fidelity Storyboard

## Defined MVP (Minimum Viable Project): 
 - collect coins (pieces of code)
 - user collects up to 10 coins
 - pop-up appears asking user to arrange code in right order
 - the user is able to reorder the code and is told when correct
 - basic platformer, main floor and 2 additional floors the user cna jump to
 - basic WASD movement (left,right,up,down(gravity))
 - the ability ot jump (to be able to reach teh additional platforms)


## Initial Test Plan

| ID | Name | Description |
| --- |----- | ----- |
| 1 | Finish State | the user can finish a section of code |
| 2| Coin collection| the user is able to collect a coin, adding to their "score"|
|3| Safe Restart| the user is give the option to restart the game and have code snippets and score reset |
|4| Order Code | the user is able to reorder code when 10/10 coins are reached|
|5| Platform interaction| ensure the platforms can be interacted with by the user correctly and theres no phasing problems|
|6|Score Update| make sure the users score is updated when coins are collected|


