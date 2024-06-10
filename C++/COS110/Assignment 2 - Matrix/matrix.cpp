#include "matrix.h"

///////////////////////////////////////////////
// TASK 1
///////////////////////////////////////////////

// CONSTRUCTOR
Matrix::Matrix(unsigned r, unsigned c)
{
    this->rows = r;
    this->cols = c;

    this->matrix = new double *[rows];

    for (int i = 0; i < rows; i++)
    {
        this->matrix[i] = new double[cols];
        for (int j = 0; j < c; j++)
        {
            this->matrix[i][j] = 0.00;
        }
    }

    /*this->linearDeterminants = nullptr;
    this->linearSolutions = nullptr;
    this->denominator = 0.00;*/
}

// COPY CONSTRUCTOR
Matrix::Matrix(const Matrix &rhs)
{
    // this->~Matrix();
    /*for (int i = 0; i < rows; i++)
    {
        delete[] this->matrix[i];
    }
    delete[] this->matrix;
    this->matrix = nullptr;*/

    this->rows = rhs.getRows();
    this->cols = rhs.getCols();
    // this->denominator = rhs.denominator;

    this->matrix = new double *[rows];
    for (int i = 0; i < rows; i++)
    {
        this->matrix[i] = new double[cols];
        for (int j = 0; j < cols; j++)
        {
            this->matrix[i][j] = rhs.matrix[i][j];
            // rhs(i, j);
            //  this->matrix[i][j] = rhs.operator()(i, j);
        }
    }

    /*this->linearDeterminants = rhs.linearDeterminants;
    this->linearSolutions = rhs.linearSolutions;
    this->denominator = rhs.denominator;*/
}

// DESTRUCTOR
Matrix::~Matrix()
{
    for (int i = 0; i < rows; i++)
    {
        delete[] this->matrix[i];
    }
    delete[] this->matrix;

    /*delete[] this->linearDeterminants;
    delete[] this->linearSolutions;

    this->matrix = nullptr;
    this->linearDeterminants = nullptr;
    this->linearSolutions = nullptr;*/
}

// ASSIGNMENT OPERATOR OVERLOADING
const Matrix &Matrix::operator=(const Matrix &rhs)
{
    // this->~Matrix();
    for (int i = 0; i < rows; i++)
    {
        delete[] this->matrix[i];
    }
    delete[] this->matrix;
    this->matrix = nullptr;

    this->rows = rhs.getRows();
    this->cols = rhs.getCols();

    // CREATE A NEW MATRIX WITH EQUAL TO THE RHS MATRIX
    this->matrix = new double *[rows];

    for (int i = 0; i < rows; i++)
    {
        matrix[i] = new double[cols];

        for (int j = 0; j < cols; j++)
        {
            // matrix[i][j] = rhs.matrix[i][j];
            this->matrix[i][j] = rhs.matrix[i][j];
            // rhs(i, j);
            // this->matrix[i][j] = rhs.operator()(i, j);
        }
    }

    /*this->linearDeterminants = rhs.linearDeterminants;
    this->linearSolutions = rhs.linearSolutions;
    this->denominator = rhs.denominator;*/

    return *this;
}

// CIN OPERATOR OVERLOADING
istream &operator>>(istream &s, Matrix &m)
{
    for (int i = 0, r = m.getRows(); i < r; i++)
    {
        for (int j = 0, c = m.getCols(); j < c; j++)
        {
            s >> m(i, j);
        }
    }

    return s;
}

// COUT OPERATOR OVERLOADING
ostream &operator<<(ostream &strm, const Matrix &m)
{
    for (int i = 0, r = m.getRows(); i < r; i++)
    {
        for (int j = 0, c = m.getCols(); j < c; j++)
        {
            strm << setw(10) << setprecision(3) << m.matrix[i][j];
        }
        strm << endl;
    }

    return strm;
}

// Access the individual elements
double &Matrix::operator()(const unsigned r, const unsigned c)
{
    return matrix[r][c];
}

const double &Matrix::operator()(const unsigned r, const unsigned c) const
{
    return matrix[r][c];
}

Matrix Matrix::operator[](const unsigned r) const
{
    Matrix mat(1, cols);
    for (int i = 0; i < cols; i++)
    {
        mat.matrix[0][i] = this->matrix[r][i];
    }
    return mat;
}

// Getters and setters:
unsigned Matrix::getRows() const
{
    return rows;
}

unsigned Matrix::getCols() const
{
    return cols;
}

///////////////////////////////////////////////
// TASK 2
///////////////////////////////////////////////

// Matrix/scalar operations
Matrix Matrix::operator*(const double &rhs)
{
    Matrix mat(rows, cols);

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            mat.matrix[i][j] = this->matrix[i][j] * rhs;
        }
    }

    return mat;
}

Matrix &Matrix::operator*=(const double &rhs)
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            matrix[i][j] = matrix[i][j] * rhs;
        }
    }

    return *this;
}

Matrix Matrix::operator/(const double &rhs)
{
    if (rhs != 0.00)
    {
        // cout << "inside divide" << endl;
        Matrix mat(rows, cols);

        // cout << mat << endl;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                mat.matrix[i][j] = matrix[i][j] / rhs;
            }
        }

        // cout << mat << endl;
        // cout << "outside divide" << endl;
        return mat;
    }
    else
    {
        cout << "Error: division by zero\n";
        return *this;
    }

    return *this; // shouldnt get to this
}

// Matrix mathematical operations
Matrix Matrix::operator+(const Matrix &rhs)
{
    // CHECK FOR ROW COMPATIBILITY
    if (rows == rhs.getRows() && cols == rhs.getCols())
    {
        Matrix mat(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                mat.matrix[i][j] = this->matrix[i][j] + rhs.matrix[i][j];
            }
        }

        return mat;
    }
    else
    {
        cout << "Error: adding matrices of different dimensionality" << endl;
        return *this;
    }

    return *this; // program should not get to this
}

Matrix &Matrix::operator+=(const Matrix &rhs)
{
    // CHECK FOR ROW COMPATIBILITY
    if (rows == rhs.getRows() && cols == rhs.getCols())
    {
        // Matrix mat(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                this->matrix[i][j] += rhs.matrix[i][j];
            }
        }

        return *this;
    }
    else
    {
        cout << "Error: adding matrices of different dimensionality" << endl;
        return *this;
    }

    return *this; // program should not get to this
}

Matrix Matrix::operator-(const Matrix &rhs)
{
    // CHECK FOR ROW COMPATIBILITY
    if (rows == rhs.getRows() && cols == rhs.getCols())
    {
        Matrix mat(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                mat.matrix[i][j] = this->matrix[i][j] - rhs.matrix[i][j];
            }
        }

        return mat;
    }
    else
    {
        cout << "Error: subtracting matrices of different dimensionality" << endl;
        return *this;
    }

    return *this; // program should not get to this
}

Matrix &Matrix::operator-=(const Matrix &rhs)
{
    // CHECK FOR ROW COMPATIBILITY
    if (rows == rhs.getRows() && cols == rhs.getCols())
    {
        // Matrix mat(rows, cols);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                this->matrix[i][j] -= rhs.matrix[i][j];
            }
        }

        return *this;
    }
    else
    {
        cout << "Error: subtracting matrices of different dimensionality" << endl;
        return *this;
    }

    return *this; // program should not get to this
}

Matrix Matrix::operator*(const Matrix &rhs)
{
    if (this->cols == rhs.getRows())
    {
        Matrix mat(this->rows, rhs.getCols());

        for (int i = 0; i < this->rows; i++)
        {
            for (int j = 0; j < rhs.getCols(); j++)
            {
                for (int k = 0; k < rhs.getRows(); k++)
                {
                    mat.matrix[i][j] += this->matrix[i][k] * rhs.matrix[k][j];
                }
            }
        }
    }
    else
    {
        cout << "Error: invalid matrix multiplication\n";
        return *this;
    }

    return *this; // shouldnt get to this
}

Matrix &Matrix::operator*=(const Matrix &rhs)
{
    Matrix mat(this->operator*(rhs));

    this->~Matrix();

    // this->rows = mat.getRows();
    // this.cols = mat.getCols();
    this->operator=(mat);
    // this = operator= mat;

    return *this;
}

Matrix Matrix::operator^(int pow)
{
    if (this->rows != this->cols)
    {
        cout << "Error: non-square matrix provided\n";
        return *this;
    }

    if (pow < 0)
    {
        cout << "Error: negative power is not supported\n";
        return *this;
    }

    if (pow == 0)
    {
        Matrix mat(this->rows, this->cols);
        for (int i = 0; i < this->rows; i++)
        {
            for (int j = 0; j < this->cols; j++)
            {
                if (i == j)
                {
                    mat.matrix[i][j] = 1;
                }
            }
        }
        return mat;
    }

    Matrix mat(*this);

    /*for (int i = 0; i < this->rows; i++)
    {
        for (int j = 0; j < this->cols; j++)
        {
            mat.matrix[i][j] = this->matrix[i][j];
        }
    }*/

    for (int i = 0; i < pow; i++)
    {
        mat.operator*=(*this);
    }

    return mat;
}

Matrix &Matrix::operator^=(int pow)
{
    if (this->rows != this->cols)
    {
        cout << "Error: non-square matrix provided\n";
        return *this;
    }

    if (pow < 0)
    {
        cout << "Error: negative power is not supported\n";
        return *this;
    }

    if (pow == 0)
    {
        for (int i = 0; i < this->rows; i++)
        {
            for (int j = 0; j < this->cols; j++)
            {
                if (i == j)
                {
                    this->matrix[i][j] = 1;
                }
                else
                {
                    this->matrix[i][j] = 0.00;
                }
            }
        }
        return *this;
    }

    Matrix mat(*this);

    for (int i = 0; i < pow; i++)
    {
        this->operator*=(mat);
    }

    mat.~Matrix();
    return *this;
}

// Linear equations:
double Matrix::operator~() // PASSED TESTING
{
    if ((this->rows != this->cols) || (this->rows != 2 && this->rows != 3))
    {
        cout << "Error: invalid matrix dimensions\n";
        return 0;
    }

    double result = 0.00;

    if (this->rows == 2)
    {
        result = this->matrix[0][0] * this->matrix[1][1] - this->matrix[1][0] * this->matrix[0][1];
    }
    else if (this->rows == 3)
    {
        double det1, det2, det3;

        det1 = this->matrix[0][0] * (this->matrix[1][1] * this->matrix[2][2] - this->matrix[2][1] * this->matrix[1][2]);
        det2 = this->matrix[0][1] * (this->matrix[1][0] * this->matrix[2][2] - this->matrix[2][0] * this->matrix[1][2]);
        det3 = this->matrix[0][2] * (this->matrix[1][0] * this->matrix[2][1] - this->matrix[2][0] * this->matrix[1][1]);

        result = det1 - det2 + det3;
    }

    return result;
}

double *Matrix::operator|(Matrix &rhs) // PASSED TESTING
{
    if (this->rows != this->cols)
    {
        cout << "Error: non-square matrix provided\n";
        return NULL;
    }

    if ((this->rows != 2 && this->rows != 3))
    {
        cout << " Error: incorrect number of variables\n";
        return NULL;
    }

    if (rhs.getCols() != 1 || this->rows != rhs.getRows())
    {
        cout << "Error: Incorrect number of variables\n";
        return NULL;
    }

    Matrix mat(*this);
    double *linearDeterminants = new double[this->rows];

    for (int i = 0; i < this->cols; i++)
    {
        for (int j = 0; j < this->rows; j++)
        {
            mat.matrix[j][i] = rhs.matrix[j][0];
        }
        linearDeterminants[i] = mat.operator~();
        mat = *this;
    }

    return linearDeterminants;
}

Matrix Matrix::operator|=(Matrix &rhs)
{
    // denominator = this->operator~();
    // this->linearDeterminants = this->operator|(rhs);

    if (this->denominator == 0)
    {
        cout << "Error: division by zero\n";
        return *this;
    }

    if (this->linearDeterminants != NULL && denominator != 0)
    {

        this->linearSolutions = new double[this->rows];

        for (int i = 0; i < this->rows; i++)
        {
            this->linearSolutions[i] = this->linearDeterminants[i] / denominator;
        }
        Matrix mat();
        return mat;
        // return *this;
    }
}