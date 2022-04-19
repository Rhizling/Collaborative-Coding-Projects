package deckOfCards;

public class Card implements Comparable<Card> {

	private int cardNum;
	private int cowHeadNum;
	private String filePath;

	public Card(int cardNum) {

		this.cardNum = cardNum;

		if (cardNum % 11 == 0) {
			cowHeadNum = 5;
		} else if (cardNum % 10 == 0) {
			this.cardNum = 3;
		} else if (cardNum % 5 == 0) { // redundant to include (cardNum % 10 != 0)
			cowHeadNum = 2;
		} else {
			cowHeadNum = 1;
		}

		if (cardNum == 55) {
			cowHeadNum = 7;
		}

		filePath = "Images/" + String.valueOf(cardNum) + ".png";

	}

	public int getCardNumber() {
		return cardNum;
	}

	public int getCowHeadNum() {
		return cowHeadNum;
	}

	public String getFilePath() {
		return this.filePath;
	}

	@Override
	public int compareTo(Card card) {
		return this.cardNum - card.cardNum;
	}

}
