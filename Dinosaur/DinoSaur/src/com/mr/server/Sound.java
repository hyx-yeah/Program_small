/**
 * 
 */
package com.mr.server;

import java.io.FileNotFoundException;

public class Sound {
	static final String DIR = "music/";								//音乐文件夹
	static final String BACKGROUND = "background.wav";				//背景音乐
	static final String JUMP = "jump.wav";							//跳跃音乐
	static final String HIT = "hit.wav";							//撞击音乐
	
	/**
	 * 播放声音
	 * @param file 音乐文件完整路径名称
	 * @param circulate 是否循环播放
	 */
	
	private static void play(String file,boolean circulate) {
		try {
			MusicPlayer player = new MusicPlayer(file, circulate);	//创建音乐播放器
			player.play();											//开始播放
		}catch (FileNotFoundException e) {
			// TODO: handle exception
			e.printStackTrace();
		}
	}
	
	/**
	 * 播放跳跃音效
	 */
	
	public static void jump() {
		play(DIR + JUMP, false);									//播放一次跳跃音乐
	}
	
	/**
	 * 播放撞击音效
	 */
	
	public static void hit() {
		play(DIR + HIT, false);										//播放一次撞击音乐
	}
	
	/**
	 * 播放背景音效
	 */
	public static void background() {
		play(DIR + BACKGROUND, true);								//循环播放背景音乐
	}
}
