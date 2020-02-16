using System;
using System.Windows.Forms;

namespace calculator
{
  public partial class CalculatorForm : Form
  {
    private static readonly string _invalidOperation = "Invalid operation was specified";
    private static readonly string _divisionByZeroErrorMessage = "Division by zero is not allowed";    
    private static readonly string _sqrtText = "^0.5";
    private static readonly string _sqrText = "^2";
    private static readonly string _sinText = "SIN";
    private static readonly string _cosText = "COS";
    private static readonly string _equalsText = "=";
    private double _result;
    private Operation _operation;

    public CalculatorForm()
    {
      InitializeComponent();
    }

    private void NumericalButtonClick(object sender, EventArgs e)
    {
      Button button = (Button)sender;
      textBoxResult.Text += button.Text;
      labelEquation.Text += button.Text;      
    }

    private void ButtonCloseClick(object sender, EventArgs e)
    {
      Close();
    }    

    private void Solve(object sender, EventArgs e)
    {
      try
      {
        Calculate();
        labelEquation.Text = $"{labelEquation.Text} {_equalsText} {_result}";
        textBoxResult.Text = _result.ToString();
        SetDefaultValues();
      }
      catch (DivideByZeroException dex)
      {
        // TODO: log exception de
        MessageBox.Show(_divisionByZeroErrorMessage);
      }
      catch (Exception ex)
      {
        MessageBox.Show("Unknown error occured");        
      }      
    }

    private void Calculate()
    {
      double currentValue = 0;
      if (!Double.TryParse(textBoxResult.Text, out currentValue))
      {
        return;
      }

      switch (_operation)
      {
        case Operation.Add:
          _result += currentValue;
          break;
        case Operation.Subtract:          
          _result -= currentValue;
          break;
        case Operation.Divide:
          _result /= currentValue; 
          break;
        case Operation.Multiple:
          _result *= currentValue;
          break;
        case Operation.Sqr:
          _result = currentValue *  currentValue;
          break;
        case Operation.Sqrt:
          _result = Math.Sqrt(currentValue);
          break;
        case Operation.Sin:
          _result = Math.Sin(currentValue);
          break;
        case Operation.Cos:
          _result = Math.Cos(currentValue);
          break;
        case Operation.None:
          _result = currentValue;
          return;
        default:
          MessageBox.Show(_invalidOperation);
          break;
      }
    }

    private void SetDefaultValues()
    {
      _result = 0;
      _operation = Operation.None;
    }

    private void ButtonClearClick(object sender, EventArgs e)
    {
      textBoxResult.Clear();
      labelEquation.Text = "";
      SetDefaultValues();
    }

    private void Add(object sender, EventArgs e)
    {      
      Calculate();
      _operation = Operation.Add;
      labelEquation.Text += buttonAdd.Text;      
      textBoxResult.Clear();
    }

    private void Subtract(object sender, EventArgs e)
    {      
      Calculate();
      _operation = Operation.Subtract;
      labelEquation.Text += buttonSubtract.Text;      
      textBoxResult.Clear();
    }

    private void Divide(object sender, EventArgs e)
    {
      try
      {       
        Calculate();
        _operation = Operation.Divide;
        labelEquation.Text += buttonDivide.Text;        
      }
      catch (DivideByZeroException)
      {
        // TODO: log error message
        MessageBox.Show(_divisionByZeroErrorMessage);
      }

      textBoxResult.Clear();
    }

    private void Multiple(object sender, EventArgs e)
    {      
      Calculate();
      _operation = Operation.Multiple;
      labelEquation.Text += buttonMultiple.Text;     
      textBoxResult.Clear();
    }

    private void Sqr(object sender, EventArgs e)
    {
      _operation = Operation.Sqr;
      Calculate();      
      labelEquation.Text = $"{labelEquation.Text} {_equalsText} {_result}";
      textBoxResult.Text = _result.ToString();
      SetDefaultValues();
    }

    private void Sqrt(object sender, EventArgs e)
    {
      _operation = Operation.Sqrt;
      Calculate();
      labelEquation.Text = $"{labelEquation.Text} {_equalsText} {_result}";
      textBoxResult.Text = _result.ToString();
      SetDefaultValues();
    }

    private void Sin(object sender, EventArgs e)
    {
      _operation = Operation.Sin;
      Calculate();
      labelEquation.Text = $"{labelEquation.Text} {_equalsText} {_result}";
      textBoxResult.Text = _result.ToString();
      SetDefaultValues();
    }

    private void Cos(object sender, EventArgs e)
    {
      _operation = Operation.Cos;
      Calculate();
      labelEquation.Text = $"{labelEquation.Text} {_equalsText} {_result}";
      textBoxResult.Text = _result.ToString();
      SetDefaultValues();
    }

    private void Plot(object sender, EventArgs e)
    {
      this.Visible = false;
      GraphForm graphForm = new GraphForm();
      graphForm.ShowDialog();
      this.Visible = true;
    }
  }
}
