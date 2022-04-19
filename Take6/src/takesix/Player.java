package takesix;

import java.util.ArrayList;
import java.util.Collections;
import java.util.Comparator;
import deckOfCards.*;

public class Player implements Comparable<Player> {
	ArrayList<Card> hand;
	Deck currentDeck;
	Card chosenCard;
	int playerNum;
	int playerScore;
	int position;

	public Player(int playerNum) {
		hand = new ArrayList<>(10);
		chosenCard = null;
		this.playerNum = playerNum;
		playerScore = 0;
	}

	public void setPosition(int position) {
		this.position = position;
	}
	
	public int getPosition() {
		return position;
	}
	
	public void setCards() {
		for (int card = 0; card < 10; card++) {
			hand.add(currentDeck.dealOneCard());
		}
	}

	public void setChoice(Card card) {
		chosenCard = card;	
	}
	
	public Card makeChoice() {
		chosenCard = hand.get(0);
		return chosenCard;
	}

	public int getPlayerNum() {
		return playerNum;
	}

	public int getPlayerScore() {
		return playerScore;
	}

	public ArrayList<Card> getHand() {
		return hand;
	}

	public int playerNum() {
		return playerNum;
	}

	public int compareTo(Player other) {
		return chosenCard.compareTo(other.chosenCard);
	}

	public static void sortByPlayerNum(ArrayList<Player> list) {
		Collections.sort(list, new Comparator<Player>() {
			@Override
			public int compare(Player a, Player b) {
				return a.playerNum - b.playerNum;
			}
		});
	}

	public int clearRow() {
		return 0;

	}

}
