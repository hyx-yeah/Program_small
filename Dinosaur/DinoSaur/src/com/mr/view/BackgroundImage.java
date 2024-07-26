/**
 * 
 */
package com.mr.view;

import java.awt.Graphics2D;
import java.awt.image.BufferedImage;
import java.io.File;
import java.io.IOException;

import javax.imageio.ImageIO;

/**
 * BackgroundImage类就是滚动背景类，
 * 该类中的image属性就是滚动背景用于展示的图片，
 * image图片是由两个私有属性image1和image2拼接出来的，
 * image1和image2会随着游戏时间的推移而不断向左移动
 */
public class BackgroundImage {
	public BufferedImage image;							//背景图片
	private BufferedImage image1,image2;				//滚动的两个图片
	private Graphics2D graphics2d;						//背景图片的绘图对象
	public int x1,x2;									//两个滚动图片的坐标
	public static final int SPEED = 4;					//滚动速度
	
	public BackgroundImage(){
		try {
			image1 = ImageIO.read(new File("image/背景.png"));
			image2 = ImageIO.read(new File("image/背景2.png"));
		} catch (IOException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
		
		//主图片采用宽800、高300的彩色图片
		image = new BufferedImage(800, 300, BufferedImage.TYPE_INT_RGB);
		graphics2d = image.createGraphics();				//获取主图片绘图对象
		x1 = 0;												//第一幅图片初始横坐标为0
		x2 = 800;											//第二幅图片初始横坐标为800
		graphics2d.drawImage(image, x1, 0, null);
	}
	
	
	/**
	 * roll()方法就是让背景持续滚动,
	 * roll()方法中只需让image1和image2的横坐标不断递减，
	 * 当任何一张图片移动出游戏画面之后，就立即回到右侧的初始位置，准备下一轮的滚动
	 */
	public void roll() {
		x1 -= SPEED;
		x2 -= SPEED;										//两幅图左移
		if(x1 <= -800) {									//如果第一幅图移出屏幕
			x1 = 800;										//回到屏幕右侧
		}
		if(x2 <= -800) {									//如果第二幅图移出屏幕
			x2 = 800;										//回到屏幕右侧
		}
		graphics2d.drawImage(image1, x1, 0, null);			//在主图片中绘制两幅图片
		graphics2d.drawImage(image2, x2, 0, null);
	}
}
