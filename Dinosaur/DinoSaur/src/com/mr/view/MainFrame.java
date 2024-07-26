/**
 * 
 */
package com.mr.view;

import java.awt.Container;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;
import javax.swing.JFrame;

import com.mr.server.ScoreRecorde;
import com.mr.server.Sound;

/**
 * MainFrame类表示游戏的主窗体类,该类继承于JFrame类
 * MainFrame类没有成员属性MainFrame类的构造方法中定义了窗体的宽、高、标题等特性，
 * 同时也具有游戏启动时的初始化功能
 */
@SuppressWarnings("serial")
public class MainFrame extends JFrame {
	public MainFrame() {
		restart();
		setBounds(340,150,820,240);					//主窗体宽：820px,高：240px
		setTitle("奔跑吧！小恐龙！");					//设置标题
		Sound.background();							//循环播放背景音乐
		ScoreRecorde.init();						//读取得分记录
		addListener();								//添加监听
		setDefaultCloseOperation(EXIT_ON_CLOSE);	//关闭窗体则停止程序
	}
	
	public void restart() {
		Container container = getContentPane();		//获取主窗口对象
		container.removeAll();						//删除容器中的所有组件
		GamePanel panel = new GamePanel();			//创建新的游戏面板
		container.add(panel);
		addKeyListener(panel);						//添加键盘事件
		addMouseListener(panel);
		container.validate();						//窗口重新验证所有组件
	}
	
	/**
	 * addListener()方法用于让主窗体添加键盘监听以外的监听事件 
	 */
	private void addListener() {
		addWindowListener(new WindowAdapter() {			//添加窗体监听
			public void windowClosing(WindowEvent e) {	//窗体关闭前
				ScoreRecorde.saveScores();				//保存得分记录
				System.exit(0);
			}
		});
	}
}
