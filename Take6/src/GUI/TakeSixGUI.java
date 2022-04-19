package GUI;

import java.awt.*;
import java.util.*;
import javax.swing.*;
import takesix.*;
import deckOfCards.*;
import java.awt.event.*;

public class TakeSixGUI implements ActionListener {

	private TakeSixModel game;
	private JFrame frame;
	private JPanel contentPane;
	private JPanel usersSideContainer; // box layout vertical
	private JPanel gameUserCardsContainer; // box layout vertical
	private JPanel actualGameContainer; // grid layout
	private JLabel turnLabel = new JLabel("Turn: Player 1");
	private ArrayList<JButton> buttonsForCurrentUser;
	private ArrayList<Player> overallPlayers;
	private int size;
	private ArrayList<Card> overallCards;
	private static int turn;

	public void actionPerformed(ActionEvent event) {
		String nameOfEvent = event.getActionCommand();
		turn++;

		Player currPlayer = overallPlayers.get(turn - 1);
		System.out.println("Player Point " + currPlayer.getPosition());
		for (int i = 0; i < currPlayer.getHand().size(); i++) {
			if (nameOfEvent.equals(currPlayer.getHand().get(i).getFilePath())) {
				overallCards.add(currPlayer.getHand().get(i));
				currPlayer.setChoice(currPlayer.getHand().get(i));
				
			}
		}

		boolean included = false;
		if (turn + 1 > size) {
			for (int i = 0; i < overallPlayers.size(); i++) {
				ArrayList<Player> players = new ArrayList<Player>(overallPlayers);
				Collections.sort(players);
				Card applicableCard = overallCards.get(players.get(i).getPlayerNum() - 1);
				ArrayList<Integer> possibleRows = game.returnValidRow(applicableCard);
				
				if (possibleRows.size() == 1) {
					for (int j = 0; j < 4; j++) {
						for (int k = 0; k < 6; k++) {
							if (j == possibleRows.get(0)) {
								if (included == false
										&& actualGameContainer.getComponent((6 * i) + j).getName().equals("Default")) {
									included = true;
									JLabel labela = (JLabel) (actualGameContainer.getComponent(6 * i + j));
									labela.setIcon(new ImageIcon(applicableCard.getFilePath()));
								}
							}
						}
					}
				}
			}

			turn = 0;
			overallCards = new ArrayList<Card>();

			Player firstPlayer = overallPlayers.get(0);
			for (int i = 0; i < 10; i++) {
				String filePath = firstPlayer.getHand().get(i).getFilePath();
				buttonsForCurrentUser.get(i).setIcon(new ImageIcon(filePath));
				buttonsForCurrentUser.get(i).setName(filePath);
			}
		} else {
			Player laterPlayer = overallPlayers.get(turn);
			

			for (int i = 0; i < 10; i++) {
				String filePath = laterPlayer.getHand().get(i).getFilePath();
				buttonsForCurrentUser.get(i).setIcon(new ImageIcon(filePath));
				buttonsForCurrentUser.get(i).setName(filePath);
				buttonsForCurrentUser.get(i).setActionCommand(filePath);
			}

		}
	}

	/*
	 * public static void main(String[] args) {
	 * javax.swing.SwingUtilities.invokeLater(new Runnable() { public void run() {
	 * Thread.currentThread().setPriority(Thread.MAX_PRIORITY); new TakeSixGUI(); }
	 * });
	 * 
	 * }
	 */

	public TakeSixGUI() {
		game = new TakeSixModel();
		JFrame frame = new JFrame("Take 6!");
		frame.getContentPane().setBackground(new Color(255, 204, 0));
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setSize(new Dimension(1000, 700));

		overallPlayers = new ArrayList<Player>();
		overallCards = new ArrayList<Card>();

		Player p1 = new Player(1);
		Player p2 = new Player(2);
		p1.setPosition(1);
		p2.setPosition(2);
		game.addPlayer(p1);
		game.addPlayer(p2);
		overallPlayers.add(p1);
		overallPlayers.add(p2);
		size = 2;
		turn = 0;

		game.setGame();

		usersSideContainer = new JPanel();
		gameUserCardsContainer = new JPanel();
		actualGameContainer = new JPanel();
		contentPane = new JPanel();

		usersSideContainer.setLayout(new BoxLayout(usersSideContainer, BoxLayout.Y_AXIS));
		gameUserCardsContainer.setLayout(new BoxLayout(gameUserCardsContainer, BoxLayout.X_AXIS));
		actualGameContainer.setLayout(new GridLayout(4, 6));
		contentPane.setLayout(new BoxLayout(contentPane, BoxLayout.X_AXIS));

		buttonsForCurrentUser = new ArrayList<JButton>();
		for (int i = 0; i < 10; i++) {
			JButton button = new JButton();
			String filePath = p1.getHand().get(i).getFilePath();
			button.addActionListener(this);
			button.setIcon(new ImageIcon(filePath));
			button.setName(filePath);
			button.setActionCommand(filePath);
			buttonsForCurrentUser.add(button);
			gameUserCardsContainer.add(button);
		}

		usersSideContainer.add(gameUserCardsContainer);

		ArrayList<Card> firstFourCards = game.firstFourCards();
		for (int i = 0; i < 4; i++) {
			for (int j = 0; j < 6; j++) {
				JLabel label = new JLabel();
				label.setName("Default");
				if (j == 0) {
					label.setIcon(new ImageIcon(firstFourCards.get(i).getFilePath()));
					label.setName("Legit");
				}

				actualGameContainer.add(label);
			}
		}

		contentPane.add(actualGameContainer);
		contentPane.add(usersSideContainer);

		frame.setContentPane(contentPane);
		frame.setVisible(true);
	}

	private void addWidgets() {

	}

	// Start gui here
	/*
	 * public static void start() { JFrame frame = new JFrame();
	 * 
	 * frame.getContentPane().setBackground(new Color(255, 204, 0));
	 * frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE); frame.setSize(new
	 * Dimension(1000, 700));
	 * 
	 * Player p1 = new Player(1); Player p2 = new Player(2); TakeSixModel game = new
	 * TakeSixModel(); // 2 players game.addPlayer(p1); game.addPlayer(p2);
	 * game.setGame();
	 * 
	 * // ArrayList<Card> cardsArrayList1 = gameDeck.getCards();
	 * 
	 * // temporary test loop, real loop will use player hand
	 * 
	 * ArrayList<Card> cardsArrayList = p1.getHand();
	 * 
	 * for (int i = 0; i < 10; i++) { frame.add(new JLabel(new
	 * ImageIcon(cardsArrayList.get(i).getFilePath()))); }
	 * 
	 * frame.setVisible(true); }
	 */

	private static void runGUI() {
		JFrame.setDefaultLookAndFeelDecorated(true);
		TakeSixGUI hotGarbage = new TakeSixGUI();
	}

	public static void main(String[] args) {
		javax.swing.SwingUtilities.invokeLater(new Runnable() {
			public void run() {
				runGUI();
			}
		});
	}
}