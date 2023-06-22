using CRUDORM_GeorgiMitev_Project.Controller;
using CRUDORM_GeorgiMitev_Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDORM_GeorgiMitev_Project.View
{
    public partial class Form1 : Form
    {
        AnimalController animalController = new AnimalController();
        AnimalTypesController animalTypesController = new AnimalTypesController();

        public Form1()
        {
            InitializeComponent();
        }

        private void LoadRecord(Animal animal)
        {
            txtBoxId.Text = animal.Id.ToString();
            txtBoxName.Text = animal.Name;
            txtBoxDescription.Text = animal.Description.ToString();
            txtBoxPrice.Text = animal.Price.ToString();
            txtBoxAge.Text = animal.Age.ToString();
            cmbBoxTypeId.Text = animal.AnimalType.Name;
            
        }

        private void ClearScreen()
        {
            txtBoxId.Clear();
            txtBoxName.Clear();
            txtBoxDescription.Clear();
            txtBoxPrice.Clear();
            txtBoxAge.Clear();
            cmbBoxTypeId.Text = "";
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            List<AnimalTypes> allAnimalTypes = animalTypesController.GetAllTypes();
            cmbBoxTypeId.DataSource = allAnimalTypes;
            cmbBoxTypeId.DisplayMember = "Name";
            cmbBoxTypeId.ValueMember = "Id";

            buttonSelect_Click(sender, e);
        }        
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBoxName.Text) || txtBoxName.Text == "")
            {
                MessageBox.Show("Въведете данни!");
                txtBoxName.Focus();
                return;
            }

            Animal newAnimal = new Animal();
            newAnimal.Name = txtBoxName.Text;
            newAnimal.Description = txtBoxDescription.Text;
            newAnimal.Price = int.Parse(txtBoxPrice.Text);
            newAnimal.Age = int.Parse(txtBoxAge.Text);
            newAnimal.AnimalTypeId = (int)cmbBoxTypeId.SelectedValue;


            animalController.Create(newAnimal);
            MessageBox.Show("Добавянето е успешно!");
            ClearScreen();
            buttonSelect_Click(sender, e);
        }

        private void buttonFind_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtBoxId.Text) || !txtBoxId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter ID!");
                txtBoxId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtBoxId.Text);
            }
            Animal animal = animalController.Get(findId);
            if (animal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД!");
                txtBoxId.Focus();
                return;
            }
            LoadRecord(animal);
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtBoxId.Text) || !txtBoxId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter ID!");
                txtBoxId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtBoxId.Text);
            }

            if (string.IsNullOrEmpty(txtBoxName.Text))
            {
                Animal animal = animalController.Get(findId);
                if (animal == null)
                {
                    MessageBox.Show("Няма такъв запис е БД!");
                    txtBoxId.Focus();
                    return;
                }
                LoadRecord(animal);
            }
            else
            {
                Animal updatedAnimal = new Animal();
                updatedAnimal.Name = txtBoxName.Text;
                updatedAnimal.Description = txtBoxDescription.Text;
                updatedAnimal.Price = int.Parse(txtBoxPrice.Text);
                updatedAnimal.Age = int.Parse(txtBoxAge.Text);
                updatedAnimal.AnimalTypeId = cmbBoxTypeId.SelectedIndex;

                animalController.Update(findId, updatedAnimal);

                MessageBox.Show("Актуализирането е успешно!");
            }
            buttonSelect_Click(sender, e);
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            int findId = 0;
            if (string.IsNullOrEmpty(txtBoxId.Text) || !txtBoxId.Text.All(char.IsDigit))
            {
                MessageBox.Show("Enter ID!");
                txtBoxId.Focus();
                return;
            }
            else
            {
                findId = int.Parse(txtBoxId.Text);
            }
            Animal findAnimal = animalController.Get(findId);
            if (findAnimal == null)
            {
                MessageBox.Show("НЯМА ТАКЪВ ЗАПИС в БД!");
                txtBoxId.Focus();
                return;
            }

            DialogResult answer = MessageBox.Show("Сигурни ли сте, че искате да изтриете Id " + findId + " ?", "Изтриване", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (answer == DialogResult.Yes)
            {
                animalController.Delete(findId);

                MessageBox.Show("Изтриването е успешно!");

                ClearScreen();
            }

            buttonSelect_Click(sender, e);
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            List<Animal> allAnimals = animalController.GetAll();
            listBox.Items.Clear();
            foreach (var item in allAnimals)
            {
                listBox.Items.Add($"{item.Id}. {item.Name}, Description: {item.Description}, Price: {item.Price}, Age: {item.Age}, Type: {item.AnimalType.Name}");
            }
        }
    }
}
