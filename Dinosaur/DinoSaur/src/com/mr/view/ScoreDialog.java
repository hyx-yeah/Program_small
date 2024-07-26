/**
 * 
 */
package com.mr.view;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.Container;
import java.awt.Font;
import java.awt.GridLayout;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.WindowAdapter;
import java.awt.event.WindowEvent;

import javax.swing.JButton;
import javax.swing.JDialog;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JPanel;

import com.mr.server.ScoreRecorde;

/**
 * 
 */
@SuppressWarnings("serial")
public class ScoreDialog extends JDialog {
	public ScoreDialog(JFrame frame) {
		super(frame, true); // 调用父类构造，阻塞父窗体
		int scores[] = ScoreRecorde.getScores(); // 获取当前前3名的成绩
		JPanel scoreJPanel = new JPanel(new GridLayout(4, 1)); // 成绩面板，4行1列
		scoreJPanel.setBackground(Color.WHITE); // 白色背景
		JLabel titleJLabel = new JLabel("英雄排行榜", JLabel.CENTER);// 标题标签居中
		titleJLabel.setFont(new Font("黑体", Font.BOLD, 20));
		titleJLabel.setForeground(Color.ORANGE);

		// 第一、二、三名标签，居中显示
		JLabel firstJLabel = new JLabel("榜首：" + scores[2], JLabel.CENTER);
		firstJLabel.setFont(new Font("黑体",Font.BOLD,16));
		firstJLabel.setForeground(Color.ORANGE);
		JLabel secondJLabel = new JLabel("榜眼：" + scores[1], JLabel.CENTER);
		secondJLabel.setFont(new Font("黑体",Font.BOLD,16));
		secondJLabel.setForeground(Color.ORANGE);
		JLabel thirthJLabel = new JLabel("探花：" + scores[0], JLabel.CENTER);
		thirthJLabel.setFont(new Font("黑体",Font.BOLD,16));
		thirthJLabel.setForeground(Color.ORANGE);
		JButton restartButton = new JButton("重新开始");
		restartButton.setForeground(Color.PINK);
		this.addWindowListener(new WindowAdapter() {
			public void windowClosing(WindowEvent e) {
				frame.dispose();
				dispose();
				System.exit(0);
			}
		});
		restartButton.addActionListener(new ActionListener() { // 增加按钮事件监听

			@Override
			public void actionPerformed(ActionEvent e) { // 当单击时
				// TODO 自动生成的方法存根
				dispose(); // 销毁对话框

			}
		});
		// 成绩面板添加标签
		scoreJPanel.add(titleJLabel);
		scoreJPanel.add(firstJLabel);
		scoreJPanel.add(secondJLabel);
		scoreJPanel.add(thirthJLabel);

		Container container = getContentPane(); // 获取主容器
		container.setLayout(new BorderLayout()); // 使用边界布局
		container.add(scoreJPanel, BorderLayout.CENTER); // 成绩面板放中间
		container.add(restartButton, BorderLayout.SOUTH); // 按钮放底部

		setTitle("游戏结束");
		int width, height;
		width = height = 200; // 对话框宽高均为200
		// 获取主窗体中居中位置的横坐标
		int x = frame.getX() + (frame.getWidth() - width) / 2;
		// 获取主窗体中居中位置的横坐标
		int y = frame.getY() + (frame.getHeight() - height) / 2;
		setBounds(x,y,width,height);						//设置坐标和宽高
		setVisible(true);									//显示对话框
	}
}
