/**
 * 
 */
package com.mr.server;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.IOException;

import javax.sound.sampled.AudioFormat;
import javax.sound.sampled.AudioInputStream;
import javax.sound.sampled.AudioSystem;
import javax.sound.sampled.DataLine;
import javax.sound.sampled.LineUnavailableException;
import javax.sound.sampled.SourceDataLine;
import javax.sound.sampled.UnsupportedAudioFileException;

/**
 * 
 */
public class MusicPlayer implements Runnable {
	File soundFile;						//音乐文件
	Thread thread;						//父线程
	boolean circulate;					//是否循环播放
	
	public MusicPlayer(String filepath) throws FileNotFoundException {
        this(filepath, false);
    }
	public MusicPlayer(String filepath,boolean circulate)
			throws FileNotFoundException{
		this.circulate = circulate;
		soundFile = new File(filepath);
		if(!soundFile.exists()) {
			throw new FileNotFoundException(filepath + "未找到");
		}
	}
	
	public void run() {
		byte[] auBuffer = new byte[1024*128];			//创建128K缓冲区
		do {
			AudioInputStream audioInputStream = null;	//创建音频输入流对象
			SourceDataLine auLine = null;				//混音频源数据行
			try {
				//从音频文件中获取音频输入流
				audioInputStream = AudioSystem.getAudioInputStream(soundFile);
				AudioFormat format = audioInputStream.getFormat();				//获取音频格式
				
				//按照源数据行类型和指定音频格式创建数据行对象
				DataLine.Info info = new DataLine.Info(SourceDataLine.class,format);
				
				//利用音频系统类型获得与指定Line.Info对象中的描述匹配的行对象
				auLine = (SourceDataLine)AudioSystem.getLine(info);
				auLine.open(format);					//按照指定格式打开源数据行
				auLine.start();							//源数据行开启读写活动
				int byteCount = 0;						//记录音频输入流读出的字节数
				while(byteCount != -1) {				//如果有读出数据
					byteCount = audioInputStream.read(auBuffer,
							0,auBuffer.length);			//从音频数据流中读出128K的数据
					if(byteCount >= 0) {				//读出有效数据
						auLine.write(auBuffer, 
								0, byteCount);	//写入数据行中
					}
				}
				
			} catch (IOException e) {
				// TODO: handle exception
				e.printStackTrace();
			}catch (UnsupportedAudioFileException e) {
				// TODO: handle exception
				e.printStackTrace();
			}catch (LineUnavailableException e) {
				// TODO: handle exception
				e.printStackTrace();
			}finally {
				auLine.drain();							//清空数据行
				auLine.close();							//关闭数据行
			}
		}while(circulate);
	}
	
	//play()方法中实例化线程对象，在构造时将本类对象作为参数传入，然后开启线程
	public void play() {
		thread = new Thread(this);						//创建线程对象
		thread.start();									//开启线程
	}
	
	//stop()方法：线程强制停止
	@SuppressWarnings("removal")
	public void stop() {
		thread.stop();									//强制关闭线程
	}
}
