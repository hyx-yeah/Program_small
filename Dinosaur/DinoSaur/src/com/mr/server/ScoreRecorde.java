/**
 * 
 */
package com.mr.server;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStreamReader;
import java.io.OutputStreamWriter;
import java.util.Arrays;

/**
 * 
 */
public class ScoreRecorde {
	private static final String SCOREFILE = "data/source";		//成绩记录文件
	private static int scores[] = new int[3];					//用于存储前3名的得分
	
	/**
	 * 初始化方法
	 */
	
	public static void init() {
		File f = new File(SCOREFILE);							//创建记录文件
		if(!f.exists()) {
			try {
				f.createNewFile();								//如果文件不存在创建新文件
			}catch (IOException e) {
				// TODO: handle exception
				e.printStackTrace();
			}
			return;
		}
		FileInputStream fis = null;
		InputStreamReader isr = null;
		BufferedReader br = null;
		try {
			fis = new FileInputStream(f);						//文件字节输入流
			isr = new InputStreamReader(fis);					//字节流转字符流
			br = new BufferedReader(isr);						//缓冲字符流‘
			String lineString = br.readLine();					//读取一行
			if(!(lineString == null||"".equals(lineString))) {	//非空
				String vString[] = lineString.split(",");		//分割字符串
				if(vString.length < 3) {
					Arrays.fill(scores, 0);						//将数张用0填充
				}
				for(int i = 0;i < Math.min(3,vString.length);i++) {
					scores[i] = Integer.parseInt(vString[i]);	//获得记录文件中的分数值
				}
			}
		} catch (FileNotFoundException e) {
			// TODO: handle exception
			e.printStackTrace();
		}catch (IOException e) {
			// TODO: handle exception
			e.printStackTrace();
		}finally {
			try {
				br.close();										//关闭缓存流
			} catch (IOException e2) {
				// TODO: handle exception
				e2.printStackTrace();
			}
			try {
				isr.close();									//关闭输入字符流
			} catch (IOException e2) {
				// TODO: handle exception
				e2.printStackTrace();
			}
			try {
				fis.close();									//关闭输入字节流
			} catch (IOException e2) {
				// TODO: handle exception
				e2.printStackTrace();
			}
		}
	}
	
	/**
	 * 成绩记录方法：在游戏停止时记录最新的3名成绩
	 */
	public static void saveScores() {
		String valueString = scores[0]+","+scores[1]+","+scores[2];//拼接得分数组
		FileOutputStream fos = null;
		OutputStreamWriter osw = null;
		BufferedWriter bw = null;
		
		try {
			fos = new FileOutputStream(SCOREFILE);					//文件字节输出流
			osw = new OutputStreamWriter(fos);						//字节输出流转字符流
			bw = new BufferedWriter(osw);							//缓冲字符流
			bw.write(valueString);									//写入拼接后的字符流
			bw.flush();												//字符流刷新
		} catch (FileNotFoundException e) {
			// TODO: handle exception
			e.printStackTrace();
		} catch (IOException e) {
			// TODO 自动生成的 catch 块
			e.printStackTrace();
		}finally {
			try {													//依次关闭流
				bw.close();											//关闭缓存流
			} catch (IOException e2) {
				// TODO: handle exception
				e2.printStackTrace();
			}
			try {
				osw.close();										//关闭输出字符流
			} catch (IOException e2) {
				// TODO: handle exception
				e2.printStackTrace();
			}
			try {
				fos.close();										//关闭输出字节流
			} catch (IOException e2) {
				// TODO: handle exception
				e2.printStackTrace();
			}
		}
	}
	
	/**
	 * 更新成绩方法：用于向成绩数组中添加新成绩
	 */
	
	public static void addNewScore(int score) {
		int temp[] = Arrays.copyOf(scores, 4);						//创建一个长度为4的临时数组，前3个元素与原得分数组同
		temp[3] = score;											//将新分数放入第4个元素
		Arrays.sort(temp);											//升序排列
		scores = Arrays.copyOfRange(temp, 1, 4);					//取最后最大的3个元素
	}
	
	/**
	 * 获取成绩方法
	 */
	public static int[] getScores() {
		return scores;
	}
}
