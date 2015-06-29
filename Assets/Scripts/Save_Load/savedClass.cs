using System.Xml;
using System.Xml.Serialization;

[System.Serializable]
public class savedClass  {

	// Use this for initialization

	public int level;
	public int total_score;
	public int level_TV;
	public int level_manocan;
	public int level_table;
	public string level_bep;
	public int level_lo;
	public int level_may;
	public int gau_bong;
	public int may_xeng;
	public int may_tinh_tien;
	public int chau_hoa;
	public string list_disk_open;
	public savedClass(){
	
	}
	public savedClass(int lev, int total_s, int level_t, int level_m, int level_ta, int level_l, int level_ma,string level_b, string list_d, int gau, int xeng, int tinhtien, int hoa){
		this.level = lev;
		this.total_score = total_s;
		this.level_TV = level_t;
		this.level_manocan = level_m;
		this.level_table = level_ta;
		this.level_bep = level_b;
		this.level_lo = level_l;
		this.level_may = level_ma;
		this.list_disk_open = list_d;
		this.gau_bong = gau;
		this.may_xeng = xeng;
		this.chau_hoa = hoa;
		this.may_tinh_tien = tinhtien;
	}
}

[System.Serializable]
public class saveLevel  
{
	public int level;
	public int money;
	public int timess;
	public int star;
	public saveLevel(){
	
	}
}