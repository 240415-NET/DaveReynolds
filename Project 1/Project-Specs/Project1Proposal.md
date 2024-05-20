Project 1 proposal:
A console app where multiple users can Store information about their collection of cards for an overpriced collectable card game.

Users will be able to Login to:

1. View their collection of cards 
2. Add or make changes their collection of cards
3. View other Users collection of cards
4. Propose trades with other users.

Models:

Users:
- Name (string)
- UID (int)

Card (abs base class)
- owner UID (int)
- Card type (string)
- Art type (string)
- Value (float)

Energy (sub -> Card)
- Elemental type(string)
    
Entity (sub -> card)
- Card name  (string) 
- Rarity (Char) C, U, R

Monster (sub entity)
- Elemental type (string)
