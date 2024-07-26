/**
 * 
 */
package com.mr.view;

import java.awt.Container;

/**
 * 
 */
public class FreshThread extends Thread{
	public static final int FREASH = 20;						//刷新时间
	GamePanel gamePanel;										//游戏面板
	
	public FreshThread(GamePanel p) {
		this.gamePanel = p;
	}
	
	public void run() {
		while(!gamePanel.isFinish()) {							//如果游戏未结束
			gamePanel.repaint();								//重绘游戏面板
			try {
				Thread.sleep(FREASH);							//按照刷新时间休眠
			} catch (InterruptedException e) {		
				// TODO: handle exception
				e.printStackTrace();
			}
		}
		Container container = gamePanel.getParent();			//获取面板父容器
		while(!(container instanceof MainFrame)) {				//如果父容器不是主窗体类
			container = container.getParent();					//继续获取父容器
		}
		MainFrame frame = (MainFrame) container;				//将容器强制转换为主窗体类
		new ScoreDialog(frame);									//弹出的成绩对话框
		frame.restart();										//主窗体重载开始游戏
	}
}
