using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace menghuanshuju
{
    public partial class Form1 : Form
    {
        //set variables

        //hero
        private int hero_class = 1;
        private int hero_lv = 60;
        private double hero_basic_status = 551.0;

        private double weapon_num = 118.0; private double cuirass_num = 0.0; private double helmet_num = 0.0; private double trinket_num = 75.0;
        private double weapon_ratio = 10.0; private double cuirass_ratio = 0.0; private double helmet_ratio = 0.0; private double trinket_ratio = 5.0;
        private double enchantment_wp_num = 30.0; private double enchantment_cr_num = 10.0; private double enchantment_hm_num = 10.0; private double enchantment_tk_num = 20.0;
        private double enchantment_wp_ratio = 15.0; private double enchantment_cr_ratio = 5.0; private double enchantment_hm_ratio = 5.0; private double enchantment_tk_ratio = 10.0;
        private double[] gear_num_list; private double[] gear_ratio_list; private double[] enchantment_num_list; private double[] enchantment_ratio_list;
        
        private double twoset_bonus = 5.0; private double fourset_bonus = 10.0; private double fourset_bonus_ratio=0.1;

        private double skill_inc_num = 0.0; private double skill_inc_ratio = 0.0;
        private double talent_inc_num = 0.0; private double talent_inc_ratio = 0.0;
        private double buff_inc_num = 0.0; private double buff_inc_ratio = 0.0;
        private double other_inc_num = 0.0; private double other_inc_ratio = 0.0;

        private double status_inc_num = 0.0; private double status_num_pe = 0.0; private double status_num_nobuff = 0.0; private double status_num_buff = 0.0;

        //soldier 
        private int soldier_lv = 60;
        private double soldier_lv1_status = 43; private double soldier_hero_correction = 20;
        private int soldier_basic_train_lv = 5; private int soldier_syn_train_lv = 10; private int soldier_enhance_train_lv = 15; private int soldier_core_train_lv = 20;
        private double soldier_basic_train_num = 10; private double soldier_syn_train_ratio = 10; private double soldier_enhance_train_num = 45; private double soldier_core_train_ratio = 40;
        private int soldier_tech_lv = 10; private double soldier_tech_inc_ratio = 30;
        private double soldier_spec_inc_num = 0; private double soldier_spec_inc_ratio = 20;
        private double soldier_other_inc_num = 0; private double soldier_other_inc_ratio = 20;
        double soldier_other_inc_num_implicit = 0.0; double soldier_other_inc_ratio_implicit = 0.0;

        private double SH_skill_inc_num = 0.0; private double SH_skill_inc_ratio = 10;
        private double SH_talent_inc_num = 0.0; private double SH_talent_inc_ratio = 0.0;
        private double SH_buff_inc_num = 0.0; private double SH_buff_inc_ratio = 20;
        private double SH_other_inc_num = 0.0; private double SH_other_inc_ratio = 0.0;

        private double soldier_basic_status = 0.0; private double soldier_basic_correction = 0.0; private double soldier_basic_total_status = 0.0;
        private double soldier_pe_status = 0.0; private double soldier_pe_correction = 0.0; private double soldier_pe_total_status = 0.0;
        private double soldier_total_status = 0.0; private double soldier_total_correction = 0.0; private double soldier_total_sum_status = 0.0;
        private double soldier_eq_inc_num = 0.0; private double soldier_eq_inc_ratio = 0.0;
        public Form1()
        {
            InitializeComponent();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label31_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private double Equiment_Hdata(out double equiment_AT_data, double base_AT_data, double[] equiment_status_Num_list, double[] enchantment_status_Num_list, double[] enchantment_status_Ratio_list)
        {
            double weapon_AT = equiment_status_Num_list[0];
            double chest_AT = equiment_status_Num_list[1];
            double helmet_AT = equiment_status_Num_list[2];
            double trinket_AT = equiment_status_Num_list[3];


            double weapon_EnAT = enchantment_status_Num_list[0];
            double chest_EnAT = enchantment_status_Num_list[1];
            double helmet_EnAT = enchantment_status_Num_list[2];
            double trinket_EnAT = enchantment_status_Num_list[3];


            double weapon_FnAT = enchantment_status_Ratio_list[0];
            double chest_FnAT = enchantment_status_Ratio_list[1];
            double helmet_FnAT = enchantment_status_Ratio_list[2];
            double trinket_FnAT = enchantment_status_Ratio_list[3];
            double suit_FnAT = enchantment_status_Ratio_list[4];

            double totol_equiment_AT_num = weapon_AT+chest_AT+helmet_AT+trinket_AT;

           
            double totol_enchantment_EnAT_num = weapon_EnAT + chest_EnAT + helmet_EnAT + trinket_EnAT;

            double totol_enchantment_FnAT_factor = weapon_FnAT  + chest_FnAT + helmet_FnAT + trinket_FnAT+ suit_FnAT;
            double totol_enchantment_FnAT_num = base_AT_data * (totol_enchantment_FnAT_factor/100);
            equiment_AT_data = totol_equiment_AT_num + totol_enchantment_EnAT_num + totol_enchantment_FnAT_num; 
            double total_base_AT = equiment_AT_data + base_AT_data;

            return total_base_AT;
        }

        private double Battle_Hdata(double base_AT_data, double equiment_AT_data, double[] equiment_AT_Ifactor_list,double enchantmentset_AT_Ifactor)
        {
            double total_base_AT = base_AT_data + equiment_AT_data;

            double weapon_AT_Ifactor = equiment_AT_Ifactor_list[0];
            double chest_AT_Ifactor = equiment_AT_Ifactor_list[1];
            double helmet_AT_Ifactor = equiment_AT_Ifactor_list[2];
            double trinket_AT_Ifactor = equiment_AT_Ifactor_list[3];

            double equiment_AT_Ifactor_num = total_base_AT * (weapon_AT_Ifactor + chest_AT_Ifactor + helmet_AT_Ifactor + trinket_AT_Ifactor)/100;
            double enchantment_AT_Ifactor_num = total_base_AT * (enchantmentset_AT_Ifactor)/100;
            double battle_AT_data = (total_base_AT + equiment_AT_Ifactor_num + enchantment_AT_Ifactor_num);

            return battle_AT_data;
        }
        
        private double Total_Hdata(double base_AT_data,double equiment_AT_data, double battle_AT_data, double talent_AT_num, double talent_AT_Ifactor, double skill_AT_num, double skill_AT_Ifactor, double buff_AT_num, double buff_AT_Ifactor, double other_buff_num, double other_buff_ratio, int hero_class)
        {
            double total_AT_data = 0.0;
            double total_base_AT2 = base_AT_data + equiment_AT_data;
            if (hero_class == 1)
                total_AT_data = battle_AT_data + total_base_AT2 * (skill_AT_Ifactor + buff_AT_Ifactor + talent_AT_Ifactor + other_buff_ratio)/100 + talent_AT_num + skill_AT_num + buff_AT_num + other_buff_num;

            return total_AT_data;
        }

        private double Battle_Sdata(double base_Soldier_AT, double command_modification, double equiment_SAT_num, double equiment_SAT_Ifactor, double soldier_Spec_num, double soldier_Spec_Ifactor, double talent_SAT_num, double talent_SAT_Ifactor, double skill_SAT_num, double skill_SAT_Ifactor)
        {
            double Battle_base_SAT = base_Soldier_AT*(100+command_modification)/100;
            double Battle_SAT = base_Soldier_AT + equiment_SAT_num + soldier_Spec_num + talent_SAT_num + skill_SAT_num + base_Soldier_AT * (equiment_SAT_Ifactor + soldier_Spec_Ifactor + talent_SAT_Ifactor + skill_SAT_Ifactor) / 100;

            return Battle_SAT;
        }

        private double Total_Sdata(double base_Soldier_AT, double command_modification, double total_static_Snum, double total_static_SIfactor, double talent_SAT_num, double talent_SAT_Ifactor, double skill_SAT_num, double skill_SAT_Ifactor, double buff_SAT_num, double buff_SAT_Ifactor, double other_SAT_num, double other_SAT_Ifactor, int hero_class)
        {
            if (hero_class == 1)
            {
                double Battle_base_SAT = base_Soldier_AT * (100 + command_modification) / 100;
                double total_SAT_num = base_Soldier_AT + total_static_Snum + talent_SAT_num + skill_SAT_num + buff_SAT_num + other_SAT_num + base_Soldier_AT * (total_static_SIfactor + talent_SAT_Ifactor + skill_SAT_Ifactor + buff_SAT_Ifactor + other_SAT_Ifactor) / 100;
                return total_SAT_num;
            }
            else
                return -1;
            
        }

        private double Soldier_Data_Formula(int soldier_hero_lv, double soldier_ini_data, double total_Ifactor_tech, double total_Inum_tech, double total_soldier_Ifactor, double total_soldier_inc_num)
        {
            double soldier_final_data = Math.Round((soldier_ini_data + (soldier_hero_lv - 1) * soldier_ini_data * 0.1) * (100 + total_soldier_Ifactor + total_Ifactor_tech) / 100 + total_soldier_inc_num + total_Inum_tech);
            return soldier_final_data;
        }

        private double Uniform_Num_Train(double inc_num,int train_lv)
        {
            double base_train_inc_num = inc_num * train_lv;
            return base_train_inc_num;
        }

        private double Uniform_Ratio_Train(double inc_ratio, int train_lv)
        {
            double base_train_inc_num = inc_ratio * train_lv;
            return base_train_inc_num;
        }

        private double Core_Ratio_Train(int train_lv)
        {
            int ii=0;
            double train_ratio = 0; double final_total_train_ratio =0;
             for (ii=1;ii<=train_lv;ii++)
             {
                 if(ii<=4)
                    train_ratio = 1;
                 else if(ii>4&&ii<=17)
                    train_ratio = 2;
                 else if (ii>17&&ii<=19)
                    train_ratio = 3;
                 else
                    train_ratio = 4;
                 final_total_train_ratio = final_total_train_ratio + train_ratio;
             }
             return final_total_train_ratio;
        }

        private double Tech_Ratio_Train(int train_lv)
        {
            int ii = 0;
            double train_ratio = 0; double final_total_train_ratio = 0;
            for (ii = 1; ii <= train_lv; ii++)
            {
                if (ii <= 3)
                    train_ratio = 2;
                else if (ii > 3 && ii <= 7)
                    train_ratio = 3;
                else
                    train_ratio = 4;
                final_total_train_ratio = final_total_train_ratio + train_ratio;
            }
            return final_total_train_ratio;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //input the value
            hero_class = System.Convert.ToInt32(HeroClass.SelectedIndex.ToString())+1;
            hero_lv = System.Convert.ToInt32(HeroLv.Text);
            hero_basic_status = System.Convert.ToDouble(HeroBasicStatus.Text);

            weapon_num = System.Convert.ToDouble(WeaponNum.Text); 
            cuirass_num = System.Convert.ToDouble(CuirassNum.Text); 
            helmet_num =System.Convert.ToDouble(HelmetNum.Text);  
            trinket_num = System.Convert.ToDouble(TrinketNum.Text);

            weapon_ratio = System.Convert.ToDouble(WeaponRatio.Text); 
            cuirass_ratio = System.Convert.ToDouble(CuirassRatio.Text); 
            helmet_ratio =System.Convert.ToDouble(HelmetRatio.Text);  
            trinket_ratio = System.Convert.ToDouble(TrinketRatio.Text);

            enchantment_wp_num = System.Convert.ToDouble(EnchantmentWpNum.Text);
            enchantment_cr_num = System.Convert.ToDouble(EnchantmentCrNum.Text); 
            enchantment_hm_num = System.Convert.ToDouble(EnchantmentHmNum.Text); 
            enchantment_tk_num = System.Convert.ToDouble(EnchantmentTkNum.Text); 

            enchantment_wp_ratio = System.Convert.ToDouble(EnchantmentWpRatio.Text);
            enchantment_cr_ratio = System.Convert.ToDouble(EnchantmentCrRatio.Text); 
            enchantment_hm_ratio = System.Convert.ToDouble(EnchantmentHmRatio.Text); 
            enchantment_tk_ratio = System.Convert.ToDouble(EnchantmentTkRatio.Text); 

            twoset_bonus = System.Convert.ToDouble(TwosetBonus.Text);
            fourset_bonus = System.Convert.ToDouble(FoursetBonus.Text);
            fourset_bonus_ratio = fourset_bonus / 100;

            skill_inc_num = System.Convert.ToDouble(SkillIncNum.Text);
            talent_inc_num = System.Convert.ToDouble(TalentIncNum.Text);
            buff_inc_num = System.Convert.ToDouble(BuffIncNum.Text);
            other_inc_num = System.Convert.ToDouble(OtherIncNum.Text);

            skill_inc_ratio = System.Convert.ToDouble(SkillIncRatio.Text);
            talent_inc_ratio = System.Convert.ToDouble(TalentIncRatio.Text);
            buff_inc_ratio = System.Convert.ToDouble(BuffIncRatio.Text);
            other_inc_ratio = System.Convert.ToDouble(OtherIncRatio.Text);
            
            gear_num_list = new double[4]{weapon_num,cuirass_num,helmet_num,trinket_num};
            gear_ratio_list = new double[4] { weapon_ratio, cuirass_ratio, helmet_ratio, trinket_ratio};
            enchantment_num_list = new double[4] { enchantment_wp_num, enchantment_cr_num, enchantment_hm_num, enchantment_tk_num };
            enchantment_ratio_list = new double[5] { enchantment_wp_ratio, enchantment_cr_ratio, enchantment_hm_ratio, enchantment_tk_ratio, twoset_bonus};
        }

        private void button2_Click(object sender, EventArgs e)
        {
            status_num_pe = Equiment_Hdata(out status_inc_num, hero_basic_status, gear_num_list, enchantment_num_list, enchantment_ratio_list);
            status_num_nobuff = Battle_Hdata(hero_basic_status, status_inc_num, gear_ratio_list, fourset_bonus);
            status_num_buff = Total_Hdata(hero_basic_status, status_inc_num, status_num_nobuff, talent_inc_num, talent_inc_ratio, skill_inc_num, skill_inc_ratio, buff_inc_num, buff_inc_ratio, other_inc_num, other_inc_ratio, hero_class);
            HeroStatusIncNum.Text = status_inc_num.ToString();
            HeroStatusIncNumPe.Text = status_num_pe.ToString();
            HeroStatusNumNobuff.Text = status_num_nobuff.ToString();
            HeroStatusNumBuff.Text = status_num_buff.ToString();
        }

        private void label33_Click(object sender, EventArgs e)
        {

        }

        private void Save1_Click(object sender, EventArgs e)
        {
            HeroStatusIncNum11.Text = HeroStatusIncNum.Text;
            HeroStatusIncNumPe1.Text = HeroStatusIncNumPe.Text;
            HeroStatusNumNobuff1.Text = HeroStatusNumNobuff.Text;
            HeroStatusNumBuff1.Text = HeroStatusNumBuff.Text;
            HeroName1.Text = HeroName.Text;
        }

        private void Save2_Click(object sender, EventArgs e)
        {
            HeroStatusIncNum2.Text = HeroStatusIncNum.Text;
            HeroStatusIncNumPe2.Text = HeroStatusIncNumPe.Text;
            HeroStatusNumNobuff2.Text = HeroStatusNumNobuff.Text;
            HeroStatusNumBuff2.Text = HeroStatusNumBuff.Text;
            HeroName2.Text = HeroName.Text;
        }

        private void Save3_Click(object sender, EventArgs e)
        {
            HeroStatusIncNum3.Text = HeroStatusIncNum.Text;
            HeroStatusIncNumPe3.Text = HeroStatusIncNumPe.Text;
            HeroStatusNumNobuff3.Text = HeroStatusNumNobuff.Text;
            HeroStatusNumBuff3.Text = HeroStatusNumBuff.Text;
            HeroName3.Text = HeroName.Text;
        }

        private void label53_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox24_TextChanged(object sender, EventArgs e)
        {

        }

        private void label54_Click(object sender, EventArgs e)
        {

        }

        private void label83_Click(object sender, EventArgs e)
        {

        }



        private void SoldireConfirm_Click(object sender, EventArgs e)
        {
            if (InheritHeroStatus.Checked == true)
            {
                SH_buff_inc_num = buff_inc_num;
                SH_buff_inc_ratio = buff_inc_ratio;
                SH_other_inc_num = other_inc_num;
                SH_other_inc_ratio = other_inc_ratio;
                SH_skill_inc_num = skill_inc_num;
                SH_skill_inc_ratio = skill_inc_ratio;
                SH_talent_inc_num = talent_inc_num;
                SH_talent_inc_ratio = talent_inc_ratio;
                soldier_lv = hero_lv;

                SoldierHeroSkillIncNum.Text = SH_skill_inc_num.ToString();
                SoldierHeroSkillIncRatio.Text = SH_skill_inc_ratio.ToString();
                SoldierHeroTalentIncNum.Text = SH_talent_inc_num.ToString();
                SoldierHeroTalentIncRatio.Text = SH_talent_inc_ratio.ToString();
                SoldierHeroBuffIncNum.Text = SH_buff_inc_num.ToString();          
                SoldierHeroBuffIncRatio.Text = SH_buff_inc_ratio.ToString();
                SoldierHeroOtherIncNum.Text = SH_other_inc_num.ToString();
                SoldierHeroOtherIncRatio.Text = SH_other_inc_ratio.ToString();
                SoldierLv.Text = soldier_lv.ToString();
              
            }
            else
            {
                SH_buff_inc_num = System.Convert.ToDouble(SoldierHeroBuffIncNum.Text);
                SH_buff_inc_ratio = System.Convert.ToDouble(SoldierHeroBuffIncRatio.Text);
                SH_other_inc_num = System.Convert.ToDouble(SoldierHeroOtherIncNum.Text);
                SH_other_inc_ratio = System.Convert.ToDouble(SoldierHeroOtherIncRatio.Text);
                SH_skill_inc_num = System.Convert.ToDouble(SoldierHeroSkillIncNum.Text);
                SH_skill_inc_ratio = System.Convert.ToDouble(SoldierHeroSkillIncRatio.Text);
                SH_talent_inc_num = System.Convert.ToDouble(SoldierHeroTalentIncNum.Text);
                SH_talent_inc_ratio = System.Convert.ToDouble(SoldierHeroTalentIncRatio.Text);
                soldier_lv  = System.Convert.ToInt32(SoldierLv.Text);
            }

            soldier_lv1_status = System.Convert.ToDouble(Lv1SoldierStatus.Text);
            soldier_hero_correction = System.Convert.ToDouble(SoldierHeroCorrection.Text);

            if (UseTrainLv.Checked == true)
            {
                soldier_basic_train_lv = System.Convert.ToInt32(SoldierBasicTrainLv.Text);
                soldier_syn_train_lv = System.Convert.ToInt32(SoldierSynTrainLv.Text);
                soldier_enhance_train_lv = System.Convert.ToInt32(SoldierEnhanceTrainLv.Text);
                soldier_core_train_lv = System.Convert.ToInt32(SoldierCoreTrainLv.Text);
                soldier_tech_lv = System.Convert.ToInt32(SoldierTechLv.Text);

                soldier_basic_train_num = Uniform_Num_Train(2, soldier_basic_train_lv);
                soldier_syn_train_ratio = Uniform_Ratio_Train(1, soldier_syn_train_lv);
                soldier_enhance_train_num = Uniform_Num_Train(3, soldier_enhance_train_lv);
                soldier_core_train_ratio = Core_Ratio_Train(soldier_core_train_lv);
                soldier_tech_inc_ratio = Tech_Ratio_Train(soldier_tech_lv);

                SoldierBasicTrainNum.Text = soldier_basic_train_num.ToString();
                SoldierSynTrainRatio.Text = soldier_syn_train_ratio.ToString();
                SoldierEnhanceTrainNum.Text = soldier_enhance_train_num.ToString();
                SoldierCoreTrainRatio.Text = soldier_core_train_ratio.ToString();
                SoldierTechIncRatio.Text = soldier_tech_inc_ratio.ToString();
            }
            else
            {
                soldier_basic_train_num = System.Convert.ToDouble(SoldierBasicTrainNum.Text);
                soldier_syn_train_ratio = System.Convert.ToDouble(SoldierSynTrainRatio.Text);
                soldier_enhance_train_num = System.Convert.ToDouble(SoldierEnhanceTrainNum.Text);
                soldier_core_train_ratio = System.Convert.ToDouble(SoldierCoreTrainRatio.Text);
                soldier_tech_inc_ratio = System.Convert.ToDouble(SoldierTechIncRatio.Text);
            }

            soldier_spec_inc_ratio = System.Convert.ToDouble(SoldierSpecIncRatio.Text);
            soldier_other_inc_ratio = System.Convert.ToDouble(SoldierOtherIncRatio.Text);
            soldier_other_inc_ratio_implicit = System.Convert.ToDouble(SoldierOtherIncRatioImplicit.Text); ;

            soldier_spec_inc_num = System.Convert.ToDouble(SoldierSpecIncNum.Text);
            soldier_other_inc_num = System.Convert.ToDouble(SoldierOtherIncNum.Text);
            soldier_other_inc_num_implicit = System.Convert.ToDouble(SoldierOtherIncNumImplicit.Text);


        }

        private void InheritHeroStatus_CheckedChanged(object sender, EventArgs e)
        {
            if (InheritHeroStatus.Checked == true)
            {
                groupBox5.Enabled = false;
            }
            else
            {
                groupBox5.Enabled = true;
            }
        }


        private void UseTrainLv_CheckedChanged(object sender, EventArgs e)
        {
            if (UseTrainLv.Checked == true)
            {
                
                SoldierBasicTrainNum.Enabled = false;
                SoldierSynTrainRatio.Enabled = false;
                SoldierEnhanceTrainNum.Enabled = false;
                SoldierCoreTrainRatio.Enabled = false;
                SoldierBasicTrainNum.Enabled = false;
                SoldierTechIncRatio.Enabled = false;

                SoldierBasicTrainLv.Enabled = true;
                SoldierSynTrainLv.Enabled = true;
                SoldierEnhanceTrainLv.Enabled = true;
                SoldierCoreTrainLv.Enabled = true;
                SoldierBasicTrainLv.Enabled = true;
                SoldierTechLv.Enabled = true;

            }
            else
            {
                SoldierBasicTrainNum.Enabled = true;
                SoldierSynTrainRatio.Enabled = true;
                SoldierEnhanceTrainNum.Enabled = true;
                SoldierCoreTrainRatio.Enabled = true;
                SoldierBasicTrainNum.Enabled = true;
                SoldierTechIncRatio.Enabled = true;

                SoldierBasicTrainLv.Enabled = false;
                SoldierSynTrainLv.Enabled = false;
                SoldierEnhanceTrainLv.Enabled = false;
                SoldierCoreTrainLv.Enabled = false;
                SoldierBasicTrainLv.Enabled = false;
                SoldierTechLv.Enabled = false;
            }
        }

        private void SoldierCalculation_Click(object sender, EventArgs e)
        {
            double total_inc_ratio_train=0.0;double total_inc_num_train=0.0; double total_inc_ratio_soldiertech=0.0;double total_inc_num_soldiertech=0.0;
            double total_inc_num_soldier =0.0; double total_inc_ratio_soldier = 0.0;double total_soldier_total_status = 0.0;
            double soldier_explicit_inc_num = 0.0; double soldier_explicit_inc_ratio = 0.0;

            total_inc_ratio_train = soldier_syn_train_ratio+soldier_core_train_ratio;
            total_inc_num_train = soldier_basic_train_num + soldier_enhance_train_num;
            total_inc_ratio_soldiertech = soldier_tech_inc_ratio;
            soldier_explicit_inc_num = soldier_spec_inc_num + soldier_eq_inc_num + soldier_other_inc_num;
            soldier_explicit_inc_ratio = soldier_spec_inc_ratio + soldier_eq_inc_ratio + soldier_other_inc_ratio;
            total_inc_num_soldier = soldier_spec_inc_num + soldier_eq_inc_num + soldier_other_inc_num + soldier_other_inc_num_implicit;
            total_inc_ratio_soldier = soldier_spec_inc_ratio + soldier_eq_inc_ratio + soldier_other_inc_ratio + soldier_other_inc_ratio_implicit;
            
            soldier_basic_status = Soldier_Data_Formula(soldier_lv, soldier_lv1_status, total_inc_ratio_train, total_inc_num_train, total_inc_ratio_soldiertech, total_inc_num_soldiertech);
            soldier_basic_correction = soldier_basic_status * soldier_hero_correction / 100;
            soldier_basic_total_status = soldier_basic_status + soldier_basic_correction;
            SoldierBasicStatus.Text = soldier_basic_status.ToString();
            SoldierBasicCorrection.Text = soldier_basic_correction.ToString();
            SoldierBasicTotalStatus.Text = soldier_basic_total_status.ToString();

            soldier_pe_status = Battle_Sdata(soldier_basic_status, soldier_hero_correction, soldier_eq_inc_num, soldier_eq_inc_ratio, soldier_explicit_inc_num, soldier_explicit_inc_ratio, SH_talent_inc_num, SH_talent_inc_ratio, SH_skill_inc_num, SH_skill_inc_ratio);
            soldier_pe_correction = soldier_pe_status * soldier_hero_correction / 100;
            soldier_pe_total_status = soldier_pe_status + soldier_pe_correction;
            SoldierPeStatus.Text = soldier_pe_status.ToString();
            SoldierPeCorrection.Text = soldier_pe_correction.ToString();
            SoldierPeTotalStatus.Text = soldier_pe_total_status.ToString();

            soldier_total_status = Total_Sdata(soldier_basic_status, soldier_hero_correction, total_inc_num_soldier, total_inc_ratio_soldier, SH_talent_inc_num, SH_talent_inc_ratio, SH_skill_inc_num, SH_skill_inc_ratio, SH_buff_inc_num, SH_buff_inc_ratio, SH_other_inc_num, SH_other_inc_ratio, hero_class);
            soldier_total_correction = soldier_total_status * soldier_hero_correction / 100;
            total_soldier_total_status = soldier_total_status + soldier_total_correction;
            SoldierBattleStatus.Text = soldier_total_status.ToString();
            SoldierBattleCorrection.Text = soldier_total_correction.ToString();
            SoldierBattleTotalStatus.Text = total_soldier_total_status.ToString();

             //private double soldier_basic_status = 0.0; private double soldier_basic_correction = 0.0; private double soldier_basic_total_status = 0.0;
       // private double soldier_pe_status = 0.0; private double soldier_pe_correction = 0.0; private double soldier_pe_total_status = 0.0;
       // private double soldier_total_status = 0.0; private double soldier_total_correction = 0.0; private double soldier_total_sum_status = 0.0;
        }

        private void label118_Click(object sender, EventArgs e)
        {

        }

        private void SoldierSave1_Click(object sender, EventArgs e)
        {
            SoldierBasicStatus1.Text = SoldierBasicStatus.Text;
            SoldierBasicCorrection1.Text = SoldierBasicCorrection.Text;
            SoldierBasicTotalStatus1.Text = SoldierBasicTotalStatus.Text;

            SoldierPeStatus1.Text = SoldierPeStatus.Text;
            SoldierPeCorrection1.Text = SoldierPeCorrection.Text;
            SoldierPeTotalStatus1.Text = SoldierPeTotalStatus.Text;

            SoldierBattleStatus1.Text = SoldierBattleStatus.Text;
            SoldierBattleCorrection1.Text = SoldierBattleCorrection.Text;
            SoldierBattleTotalStatus1.Text = SoldierBattleTotalStatus.Text;

            SoldierName1.Text = SoldierName.Text;
            SoldierHeroName1.Text = HeroName.Text;
            SoldierLv1.Text = SoldierLv.Text;

        }

        private void SoldierSave2_Click(object sender, EventArgs e)
        {
            SoldierBasicStatus2.Text = SoldierBasicStatus.Text;
            SoldierBasicCorrection2.Text = SoldierBasicCorrection.Text;
            SoldierBasicTotalStatus2.Text = SoldierBasicTotalStatus.Text;

            SoldierPeStatus2.Text = SoldierPeStatus.Text;
            SoldierPeCorrection2.Text = SoldierPeCorrection.Text;
            SoldierPeTotalStatus2.Text = SoldierPeTotalStatus.Text;

            SoldierBattleStatus2.Text = SoldierBattleStatus.Text;
            SoldierBattleCorrection2.Text = SoldierBattleCorrection.Text;
            SoldierBattleTotalStatus2.Text = SoldierBattleTotalStatus.Text;

            SoldierName2.Text = SoldierName.Text;
            SoldierHeroName2.Text = HeroName.Text;
            SoldierLv2.Text = SoldierLv.Text;
        }

        private void SoldierSave3_Click(object sender, EventArgs e)
        {
            SoldierBasicStatus3.Text = SoldierBasicStatus.Text;
            SoldierBasicCorrection3.Text = SoldierBasicCorrection.Text;
            SoldierBasicTotalStatus3.Text = SoldierBasicTotalStatus.Text;

            SoldierPeStatus3.Text = SoldierPeStatus.Text;
            SoldierPeCorrection3.Text = SoldierPeCorrection.Text;
            SoldierPeTotalStatus3.Text = SoldierPeTotalStatus.Text;

            SoldierBattleStatus3.Text = SoldierBattleStatus.Text;
            SoldierBattleCorrection3.Text = SoldierBattleCorrection.Text;
            SoldierBattleTotalStatus3.Text = SoldierBattleTotalStatus.Text;

            SoldierName3.Text = SoldierName.Text;
            SoldierHeroName3.Text = HeroName.Text;
            SoldierLv3.Text = SoldierLv.Text;
        }



    }
}
