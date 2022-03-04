using kanban_project.Models;
using kanban_project.ViewModels;

namespace kanban_project.DesignMock
{
    public class CardMock : CardViewModel
    {
        public CardMock() : base(new CardModel()
        {
            Name = "Тестовая карточка",
            Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vivamus nisl est, eleifend non pharetra vitae, egestas nec turpis. Nunc imperdiet aliquet ornare. Nunc ut convallis erat. Praesent aliquam, ipsum porttitor finibus rutrum, enim nisi sagittis sapien, a luctus libero ipsum a magna. Vivamus id mollis sapien. In feugiat mauris sit amet nisl interdum, vitae malesuada dui hendrerit. Ut eget neque in mauris tempus consectetur. Vestibulum viverra luctus egestas. Mauris convallis orci sit amet facilisis volutpat. Nulla eget molestie lectus. Proin ut diam lectus."
                + "\nInteger euismod est ac nibh condimentum faucibus.Proin consectetur mi ac enim auctor, ut auctor quam bibendum.Suspendisse vitae libero risus.Vivamus rutrum porttitor ligula, non malesuada massa tempor ut.Praesent sollicitudin vehicula nunc eu elementum.Suspendisse eu felis a lectus hendrerit vulputate id in turpis.Mauris id tellus sodales, vulputate turpis quis, hendrerit tellus.Nullam sed metus laoreet, lobortis quam et, congue turpis.Nulla at laoreet ante.Sed posuere nisi nec magna consequat tempor.Nulla quis posuere massa, vitae gravida urna."
        })
        { }
    }
}
