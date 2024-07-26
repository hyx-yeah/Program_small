/**
 * 
 */
package com.mr.view;

import java.awt.Color;
import java.awt.Font;
import java.awt.Graphics;
import java.awt.Graphics2D;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.awt.event.MouseEvent;
import java.awt.event.MouseListener;
import java.awt.image.BufferedImage;
import java.util.ArrayList;
import java.util.List;

import javax.swing.JPanel;

import com.mr.modle.Dinosaur;
import com.mr.modle.Obstacle;
import com.mr.server.ScoreRecorde;
import com.mr.server.Sound;

/**
 * 
 */
@SuppressWarnings("serial")
public class GamePanel extends JPanel implements KeyListener,MouseListener {

	private BufferedImage image;							//主图片
	private BackgroundImage background;						//背景图片
	private Dinosaur golDinosaur;							//恐龙
	private Graphics2D graphics2d;							//主图片绘图对象
	private int addObstacleTimer = 0;						//添加障碍计时器
	private boolean finish = false;							//游戏结束标志
	private List<Obstacle> list = new ArrayList<Obstacle>();//障碍集合
	private final int FREASH = FreshThread.FREASH;			//刷新时间
	int score = 0;											//得分
	int scoreTimer = 0;										//分数计时器
	
	
	public GamePanel() {
		//主图采用宽800、高300的彩色图片
		image = new BufferedImage(800,300,BufferedImage.TYPE_INT_RGB);
		graphics2d = image.createGraphics();				//获取主图片绘图对象
		background = new BackgroundImage();					//初始化滚动背景
		golDinosaur = new Dinosaur();						//初始化小恐龙
		list.add(new Obstacle());							//添加第一个障碍
		FreshThread t = new FreshThread(this);				//刷新帧线程
		t.start();											//启动线程
	}
	
	/**
	 * 在paintImage()方法中会让每一个游戏元素都执行各自的运动，
	 * 如背景图片的滚动、恐龙的移动和障碍的移动等
	 */
	private void paintImage() {
		background.roll();									//背景图片开始滚动
		golDinosaur.move();									//恐龙开始移动
		graphics2d.drawImage(background.image, 0, 0, this);	//绘制滚动背景
		if(addObstacleTimer == 1300) {						//每过1300ms
			if(Math.random()*100 > 40) {					//60%概率出现障碍
				list.add(new Obstacle());
			}
			addObstacleTimer = 0;							//重新计时
		}
		for(int i = 0;i < list.size(); i++) {				//遍历障碍集合
			Obstacle obstacle = list.get(i);				//获取障碍对象
			if(obstacle.isLive()) {							//有效障碍
				obstacle.move();							//障碍物移动
				graphics2d.drawImage(obstacle.image, 
						obstacle.x, obstacle.y, this);		//绘制障碍
				if(obstacle.getBounds().intersects(golDinosaur.getFootBounds())
						||obstacle.getBounds().intersects(golDinosaur.getHeadBounds())) {
					Sound.hit();							//播放撞击声音
					gameOver();								//游戏结束
				}
			}else {
				list.remove(i);								//如果不是有效障碍，删除
				i--;										//循环变量前移
			}
		}
		
		graphics2d.drawImage(golDinosaur.image, golDinosaur.x, 
				golDinosaur.y, this);						//绘制恐龙
		if(scoreTimer >= 500) {
			score +=  10;									//每过500ms加10分
			scoreTimer = 0;									//重新计时
		}
		graphics2d.setColor(Color.BLACK);
		graphics2d.setFont(new Font("黑体",Font.BOLD,24));	//使用黑色加粗字体
		graphics2d.drawString(String.format("%06d",score),700,30);	//绘制分数
		addObstacleTimer += FREASH;							//障碍计时器递增
		scoreTimer += FREASH;								//分数计时器递增
	}
	
	/**
	 * 将主图片绘制到面板中
	 * */
	
	public void paint(Graphics g) {
		paintImage();										//绘制主图片内容
		g.drawImage(image, 0, 0, this);
	}
	
	/**
	 * gameOver()方法可以让游戏立即结束
	 * */
	
	public void gameOver() {
		ScoreRecorde.addNewScore(score);					//记录当前分数
		finish = true;
	}
	
	/**
	 * isFinish() 方法用于判断游戏是否结束
	 * */
	public boolean isFinish() {
		return finish;
	}
	@Override
	public void keyTyped(KeyEvent e) {
		// TODO 自动生成的方法存根
		
	}

	@Override
	public void keyPressed(KeyEvent e) {
		// TODO 自动生成的方法存根
		int code = e.getKeyCode();							//获取按下的按键值
		if(code == KeyEvent.VK_SPACE) {						//如果是空格
			golDinosaur.jump();								//恐龙跳跃
		}
	}

	@Override
	public void keyReleased(KeyEvent e) {
		// TODO 自动生成的方法存根
		
	}

	@Override
	public void mouseClicked(MouseEvent e) {
		// TODO 自动生成的方法存根
		if(e.getButton() == MouseEvent.BUTTON1) {
			golDinosaur.jump();
		}
	}

	@Override
	public void mousePressed(MouseEvent e) {
		// TODO 自动生成的方法存根
		
	}

	@Override
	public void mouseReleased(MouseEvent e) {
		// TODO 自动生成的方法存根
		
	}

	@Override
	public void mouseEntered(MouseEvent e) {
		// TODO 自动生成的方法存根
		
	}

	@Override
	public void mouseExited(MouseEvent e) {
		// TODO 自动生成的方法存根
		
	}
}
