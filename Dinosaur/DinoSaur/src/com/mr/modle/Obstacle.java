package com.mr.modle;

import java.awt.Rectangle;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;
import java.util.Random;

import javax.imageio.ImageIO;
import com.mr.view.BackgroundImage;

public class Obstacle {
	public int x, y; // 横纵坐标
	public BufferedImage image; // 障碍物主图
	private BufferedImage stone; // 石头图片
	private BufferedImage cacti; // 仙人掌图片
	private int speed; // 移动速度，背景速度

	// 构造函数
	public Obstacle() {
		try {
			stone = ImageIO.read(new File("image/石头.png"));
			cacti = ImageIO.read(new File("image/仙人掌.png"));
		} catch (IOException e) {
			// TODO: handle exception
			e.printStackTrace();
		}

		// 随机成为石头或仙人掌
		Random random = new Random();
		if (random.nextInt(2) == 0) {
			image = cacti; // 随机数为0：障碍物为仙人掌
		} else {
			image = stone; // 随机数为0：障碍物为石头
		}

		x = 800;						//游戏的界面是800
		y = 200 - image.getHeight();
		speed = BackgroundImage.SPEED; 	// 移动速度与背景同步
	}

	// 移动方法
	public void move() {
		x -= speed;
	}

	// isLive()方法:检测障碍物是否在画面范围内
	// 只有存活的对象才做碰撞检测
	public boolean isLive() {
		if (x < -image.getWidth()) { // 如果移出了游戏画面
			return false; // 消亡
		}
		return true; // 存活
	}

	// 障碍的边界对象用于做碰撞检测计算
	// 要根据障碍对象的具体种类返回不同的边界对象

	public Rectangle getBounds() {
		if (image == cacti) {
			return new Rectangle(x + 7, y, 15, image.getHeight()); // 仙人掌的边界
		}
		return new Rectangle(x + 5, y + 4, 23, 21); // 石头边界
	}
}
