using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calc_HoXuanDai
{
    public partial class frmDai : Form
    {
        private bool hasDecimalPoint = false; // Biến kiểm tra dấu chấm phẩy phần thập phân
        private bool hasThousandsSeparator = false; // Biến kiểm tra dấu phân cách hàng ngàn
        string currentInput = ""; // Biến để lưu trữ biểu thức hiện tại
        double result = 0;// Kết quả
        bool isNewCalculation = true;
        bool isNegative = false;
        bool isPercentageMode = false; // Biến để theo dõi xem bạn đang ở chế độ phần trăm hay không
        string lastClickedButton = ""; // Biến để theo dõi nút cuối cùng được nhấn
        string buttonState = "Open";
        List<string> lichsu = new List<string>();
        public frmDai()
        {
            InitializeComponent();
            tt_History.SetToolTip(btn_History, "Lịch sử tính toán");
            tt_Del.SetToolTip(btnDel, "Xóa kí tự");
            tt_Cancel.SetToolTip(vbCancel, "Xóa màn hình");
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            lbl_tinh.Text = "";
            lbl_kq.Text = "";
        }
        private void btnC_Click(object sender, EventArgs e)
        {
            currentInput = "";
            lbl_tinh.Text = "";
            lbl_kq.Text = "";   
            isNewCalculation = true;
            buttonState = "Open";
        }
        private void btnDel_Click(object sender, EventArgs e)
        {
            if (currentInput.Length > 0)
            {
                currentInput = currentInput.Remove(currentInput.Length - 1); // Xóa ký tự cuối cùng
                lbl_tinh.Text = currentInput;
            }

            if (currentInput.Length == 0)
            {
                lbl_tinh.Text = "";
            }
        }
        private void onClick_history(object sender, EventArgs e)
        {
            history frm = new history();
            frm.lichsuList = lichsu;
            frm.ShowDialog();

        }

        private void btn_Operator(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string newOperator = button.Text;

            if (!isNewCalculation)
            {
                btn_Equals(sender, e);
                isNewCalculation = true;
                currentInput = result.ToString(); // Sử dụng kết quả trước đó làm phần đầu của biểu thức mới
            }
            // Thêm phép tính vào biểu thức hiện tại
            currentInput += newOperator; 
            lbl_tinh.Text = FormatNumber(currentInput);
            lbl_kq.Text = "";
        }

        private void btn_Am(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lbl_tinh.Text))
            {
                // Tìm vị trí của dấu cuối cùng trong biểu thức
                int lastIndex = currentInput.LastIndexOfAny(new char[] { '+', '-', '*', '/' });

                if (lastIndex != -1)
                {
                    // Nếu tìm thấy dấu, thay đổi dấu cuối cùng
                    char lastChar = currentInput[lastIndex];

                    if (lastChar == '+' || lastChar == '-' || lastChar == '*' || lastChar == '/')
                    {
                        // Xóa dấu cuối cùng và thay đổi thành dấu ngược lại
                        currentInput = currentInput.Remove(lastIndex, 1);
                        if (lastChar == '+') currentInput = currentInput.Insert(lastIndex, "-");
                        else if (lastChar == '-') currentInput = currentInput.Insert(lastIndex, "+");
                        else if (lastChar == '*') currentInput = currentInput.Insert(lastIndex, "*-");
                        else if (lastChar == '/') currentInput = currentInput.Insert(lastIndex, "/-");
                    }
                }
                else
                {
                    // Nếu không tìm thấy dấu, thêm dấu '-' vào cuối biểu thức
                    currentInput += "-";
                }
                lbl_tinh.Text = currentInput;
            }
        }
        private void btn_Equals(object sender, EventArgs e)
        {
            try
            {
                string expressionToEvaluate = currentInput;
                // Nếu biểu thức chứa các phép tính (+, -, *, /), tính toán kết quả
                result = EvaluateExpression(currentInput);
                // Hiển thị biểu thức trên lbl_tinh
                lbl_tinh.Text = expressionToEvaluate;
                
                lbl_kq.Text = FormatNumber(result.ToString()); 
                isNewCalculation = false;
            }
            catch (Exception ex)
            {
                lbl_tinh.Text = "Lỗi: " + ex.Message;
            }

            //lich su phép tính
            lichsu.Add($"{lbl_tinh.Text} = {lbl_kq.Text}");
           
        }
        private void onClick_Ngoac(object sender, EventArgs e)
        {
            if (buttonState == "Open")
            {
                currentInput += "(";
                buttonState = "Close"; // Chuyển sang trạng thái Đóng
            }
            else
            {
                currentInput += ")";
                buttonState = "Open"; // Chuyển sang trạng thái Mở
            }
            UpdateDisplay();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            if (button.Text == ".")
            {
                // Nếu là dấu chấm, kiểm tra đã có dấu chấm phần thập phân chưa
                if (!hasDecimalPoint)
                {
                    currentInput += button.Text;
                    hasDecimalPoint = true;
                }
            }
            else
            {
                // Kiểm tra nếu là dấu phân cách hàng ngàn
                if (button.Text == ",")
                {
                    // Nếu chưa có dấu phân cách hàng ngàn, thì thêm vào
                    if (!hasThousandsSeparator)
                    {
                        currentInput += ",";
                        hasThousandsSeparator = true;
                    }
                }
                else
                {
                    // Thêm số vào chuỗi hiện tại
                    currentInput += button.Text;
                }
            }
            // Sử dụng hàm FormatNumber để định dạng chuỗi số với dấu phân cách
            string formattedInput = FormatNumber(currentInput);

            lbl_tinh.Text = formattedInput;
        }

        // Hàm định dạng số với dấu phân cách hàng ngàn và phân thập phân
        private string FormatNumber(string input)
        {
            double number;
            if (double.TryParse(input, out number))
            {
                // Kiểm tra xem chuỗi đã chứa dấu phân cách hàng ngàn chưa
                if (input.Contains(","))
                {
                    return string.Format("{0:N2}", number); // Số 2 trong {0:N2} đại diện cho 2 chữ số sau dấu phẩy
                }
                else
                {
                    return string.Format("{0:N0}", number); // Không có dấu phân cách hàng ngàn và không có chữ số sau dấu phẩy
                }
            }
            return input;
        }       
        
        private double EvaluateExpression(string expression)
        {
            //Định dạng dấu phẩy
            expression = expression.Replace(",", ".");

            // Thay thế các ký tự phần trăm (%) bằng "/100" trong biểu thức
            expression = expression.Replace("%", "/100");

            // Sử dụng Evaluate của DataTable để tính toán biểu thức
            DataTable table = new DataTable();
            table.Columns.Add("expression", typeof(string), expression);
            DataRow row = table.NewRow();
            table.Rows.Add(row);

            return double.Parse((string)row["expression"]);
        }       

        // hàm xử lí kèm của nút %
        private void UpdateDisplay()
        {
            lbl_tinh.Text = currentInput;
        }
            
        private void tt_Del_Popup(object sender, PopupEventArgs e)
        {
            
        }
        private void tt_History_Popup(object sender, PopupEventArgs e)
        {
            
        }
        private void tt_Cancel_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
