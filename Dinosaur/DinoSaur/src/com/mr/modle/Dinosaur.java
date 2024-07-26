/**
 * 
 */
package com.mr.modle;

import java.awt.Rectangle;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;
import com.mr.server.Sound;
import com.mr.view.FreshThread;

/**
 * 
 */

//恐龙类只有两个公共属性
public class Dinosaur {
	public BufferedImage image; // 主图片
	public int x, y; // 坐标
	private BufferedImage image1, image2, image3; // 奔跑的3张图片

	private boolean jumpState = false; // 标识跳跃状态
	private int jumpValue = 0; // 跳跃的增变量
	private int stepTime = 0; // 踏步计时器，切换图片的时间

	private final int JUMP_HIGHT = 100; // 跳跃最高度
	private final int LOWEST_Y = 120; // 落地最低坐标
	private final int FREASH = FreshThread.FREASH; // 刷新时间

	// 构造函数
	public Dinosaur() {
		x = 50;
		y = LOWEST_Y;
		try {
			image1 = ImageIO.read(new File("image/恐龙1.png"));
			image2 = ImageIO.read(new File("image/恐龙2.png"));
			image3 = ImageIO.read(new File("image/恐龙3.png"));
		} catch (IOException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}

	// 踏步的方法step()
	// 每过 250 毫秒(1/4秒)，更换一张图片。因为共有3张图片，所以除以3取余，轮流展示这3张
	private void step() {
		int temp = stepTime / 250 % 3;
		switch (temp) {
		case 1: {
			image = image1;
			break;
		}
		case 2: {
			image = image2;
			break;
		}
		default:
			image = image3;
		}
		stepTime += FREASH; // 计时器递增
	}

	// 更改恐龙的jumpState跳跃状态属性
	public void jump() {
		if (!jumpState) { // 非跳跃状态下触发jump()方法，跳跃的同时也会播放跳跃音效
			Sound.jump(); // 播放跳跃音乐
		}
		jumpState = true; // 更改跳跃状态
	}

	// 体现小恐龙在奔跑的方法
	public void move() {
		step(); // 不断踏步
		if (jumpState) { // 它正在跳跃
			if (y >= LOWEST_Y) { // 纵坐标值越来越小，这样恐龙的图片位置就会越来越高
				jumpValue = -4;
			}
			if (y <= LOWEST_Y - JUMP_HIGHT) {
				jumpValue = 4; // 纵坐标值越来越大，这样恐龙的图片位置就会越来越低
			}
			y += jumpValue; // 更新纵坐标
			if (y >= LOWEST_Y) { // 恐龙跳跃落地
				jumpState = false; // 状态转换
			}
		}
	}

	/*
	 * java.awt.Rectangle类是矩形边界类 为恐龙的头部和脚部创建矩形边界对象，用于做碰撞检测。
	 */
	// getFootBounds()方法用于获取恐龙的脚部边界对象
	public Rectangle getFootBounds() {
		return new Rectangle(x + 30, y + 59, 29, 18);
	}

	// getHeadBounds()方法用于获取恐龙的脚部边界对象
	public Rectangle getHeadBounds() {
		return new Rectangle(x + 66, y + 25, 32, 22);
	}

}
