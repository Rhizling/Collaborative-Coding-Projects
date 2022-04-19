package takesix;

import deckOfCards.*;
import java.util.ArrayList;
import java.util.Random;
import java.util.Collections;
import java.util.Comparator;

public class TakeSixModel {

	ArrayList<Card>[] playingField;
	private Deck deck;
	int roundNumber;
	int facedownCards;
	private ArrayList<Player> playingOrder = new ArrayList<Player>();
	private ArrayList<Card> roundCards = new ArrayList<Card>();
	
	public void retrieveCard(Card card) {
		roundCards.add(card);
	}

	public TakeSixModel() {
		playingField = (ArrayList<Card>[]) new ArrayList[4];
		facedownCards = 0;
		for (int row = 0; row < 4; row++) {
			playingField[row] = new ArrayList<Card>(5);
		}
		deck = new Deck();
		roundNumber = 1;
	}

	// must add players before setting game
	public void addPlayer(Player p) {
		playingOrder.add(p);
		p.currentDeck = deck;
	}

	public ArrayList<Player> getOrder() {
		return playingOrder;
	}

	public Deck getDeck() {
		return deck;
	}
	
	
	
	public ArrayList<Card> firstFourCards() {
		ArrayList<Card> firstFour = new ArrayList<>(4);
		for (ArrayList<Card> row : playingField) {
			firstFour.add(row.get(0));
		}
		return firstFour;
	}

	public void setGame() {
		for (Player player : playingOrder) {
			player.setCards();
		}
		for (ArrayList<Card> row : playingField) {
			row.add(deck.dealOneCard());
		}
	}
	
	public void playRound() {
		facedownCards = 0;
		Player.sortByPlayerNum(playingOrder);
		if (roundNumber <= 10) {
			for (Player player : playingOrder) {
				player.makeChoice();
				facedownCards++;
			}
			Collections.sort(playingOrder);
		} else {
			endGame();
		}
	}

	public Player endGame() {
		Collections.sort(playingOrder, new Comparator<Player>() {
			@Override
			public int compare(Player a, Player b) {
				return a.playerScore - b.playerScore;
			}
		});
		return playingOrder.get(playingOrder.size() - 1);
	}

	// places the card for a specific player in the optimal position on the playing
	// field
	public ArrayList<Integer> returnValidRow(Card currentCard) {
		Integer lowestRow = null;
		ArrayList<Integer> toAdd = new ArrayList<>(); // defines the row that the card will be added to
		int lowestDifference = Integer.MAX_VALUE; // set to max just so it can be can be changed later
		// for each loop evaluates last card of each row to find which card has the
		// smallest positive difference from player card
		for (int index = 0; index<4; index++){
			ArrayList<Card> row = playingField[index];
			Card lastCard = row.get(row.size() - 1);
			int rowDifference = currentCard.compareTo(lastCard);
			if (rowDifference > 0 && rowDifference < lowestDifference) {
				lowestRow = index;
				lowestDifference = rowDifference;
			}
		}
		// if no row is found to add the card then the player can choose which row to
		// clear
		if (lowestRow == null) {
			toAdd.add(0);
			toAdd.add(1);
			toAdd.add(2);
			toAdd.add(3);
			return toAdd;
		} else { // card is added normally to a row or exceeds row and clears deck
			toAdd.add(lowestRow);
			return toAdd;
		}
	}

	public void placeCard(Card currentCard, int rowNumber, Player currentPlayer) {
		ArrayList<Card> row = playingField[rowNumber];
		row.add(currentCard);
		if (row.size() > 5) {
			int sum = 0;
			for (Card card : row) {
				sum += card.getCowHeadNum();
			}
			currentPlayer.playerScore += sum;
			for (int rowIndex = 0; rowIndex < row.size(); rowIndex++) {
				row.remove(0);
			}
			row.add(currentCard);
		}
	}
	
	
	
			
}
