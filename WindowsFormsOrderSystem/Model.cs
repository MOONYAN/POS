using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsOrderSystem
{
    public class Model
    {
        public delegate void MealAddedEventHandler(Meal newMeal);
        public event MealAddedEventHandler _mealAddedEvent;
        public delegate void MealDeletedEventHandler(Meal deleteMeal);
        public event MealDeletedEventHandler _mealDeletedEvent;
        public delegate void CategoryDeletedEventHandler(Category deleteCategory);
        public event CategoryDeletedEventHandler _categoryDeletedEvent;
        public delegate void CategoryAddEventHandler(Category newCategory);
        public event CategoryAddEventHandler _categoryAddEvent;
        private const string DEFAULT = "";
        private BindingList<Meal> _mealList = new BindingList<Meal>();
        private BindingList<Category> _categoryList = new BindingList<Category>();
        private Order _order = new Order();

        public Model()
        {
            FileReader reader = new FileReader();
            const string CATEGORY_PATH = "../../../CsvSource/Category.csv";
            const string MEAL_PATH = "../../../CsvSource/Meal.csv";
            InitializeCategoryList(reader.GetStringList(CATEGORY_PATH));
            InitializeMealList(reader.GetStringList(MEAL_PATH));
        }

        //initialize meal list
        private void InitializeMealList(List<string[]> rowList)
        {
            foreach (string[] stringArray in rowList)
            {
                const int COLUMN_NAME = 0;
                const int COLUMN_CATEGORY = 1;
                const int COLUMN_PRICE = 2;
                const int COLUMN_PATH = 3;
                const int COLUMN_DESCRIPTION = 4;
                string name = stringArray[COLUMN_NAME];
                Category category = _categoryList[int.Parse(stringArray[COLUMN_CATEGORY])];
                int price = int.Parse(stringArray[COLUMN_PRICE]);
                string path = stringArray[COLUMN_PATH];
                string description = stringArray[COLUMN_DESCRIPTION];
                Meal newMeal = new Meal(name, category, price, path, description);
                _mealList.Add(newMeal);
            }
        }

        //initialize category list
        private void InitializeCategoryList(List<string[]> rowList)
        {
            foreach (string[] stringArray in rowList)
            {
                Console.WriteLine(stringArray[0]);
                _categoryList.Add(new Category(stringArray[0]));
            }
        }

        // add category
        public void AddCategory(Category newCategory)
        {
            _categoryList.Add(newCategory);
            NotifyCategoryAddEvent(newCategory);
        }

        //Notify Category Add Event
        private void NotifyCategoryAddEvent(Category newCategory)
        {
            if (_categoryAddEvent != null)
            {
                _categoryAddEvent(newCategory);
            }
        }

        // add meal
        public void AddMeal(Meal newMeal)
        {
            _mealList.Add(newMeal);
            NotifyMealAddedEvent(newMeal);
        }

        //Notify Meal Added Event
        private void NotifyMealAddedEvent(Meal newMeal)
        {
            if (_mealAddedEvent != null)
            {
                _mealAddedEvent(newMeal);
            }
        }

        // pick meal
        public void PickMeal(Meal meal)
        {
            _order.PickMeal(meal);
        }

        // quit meal
        public void QuitMeal(int sequenceIndex)
        {
            _order.RemoveMeal(sequenceIndex);
        }

        // delete category
        public void DeleteCategory(Category category)
        {
            if (category != null)
            {
                _categoryList.Remove(category);
                NotifyCategoryDeletedEvent(category);
                var query = _mealList.Where(meal => meal.Category == category);
                query.ToList().ForEach(meal => _mealList.Remove(meal));
            }
        }

        //Notify Category Deleted Event
        private void NotifyCategoryDeletedEvent(Category category)
        {
            if (_categoryDeletedEvent != null)
            {
                _categoryDeletedEvent(category);
            }
        }

        // delete meal
        public void DeleteMeal(Meal meal)
        {
            if (meal != null)
            {
                _mealList.Remove(meal);
                NotifyMealDeletedEvent(meal);
            }
        }

        //Notify Meal Deleted Event
        private void NotifyMealDeletedEvent(Meal meal)
        {
            if (_mealDeletedEvent != null)
            {
                _mealDeletedEvent(meal);
            }
        }

        public Order Order
        {
            get
            {
                return _order;
            }
        }

        public BindingList<BillRecord> BillRecordList
        {
            get
            {
                return _order.BillRecordList;
            }
        }

        public BindingList<Meal> MealList
        {
            get
            {
                return _mealList;
            }
        }

        public BindingList<Category> CategoryList
        {
            get
            {
                return _categoryList;
            }
        }
    }
}