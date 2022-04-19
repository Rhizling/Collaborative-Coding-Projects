package deckOfCards;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Random;

//stores the deck of cards that will be drawn from throughout the game
public class Deck {
	private ArrayList<Card> cards;

	// adds all 104 of the standard deck cards to the deck variable
	public Deck() {
		cards = new ArrayList<Card>(104);
		for (int i = 1; i <= 104; i++) { // adds one of every card from 1 to 104; altered here
			cards.add(new Card(i));
		}
		shuffle(new Random());
	}

	public ArrayList<Card> getCards() {
		return cards;
	}

	// removes the first card in the deck's list and returns it
	public Card dealOneCard() {
		return cards.remove(0);
	}

	// randomly shuffles the deck
	public void shuffle(Random randomGenerator) {
		Collections.shuffle(cards, randomGenerator);
	}

}
