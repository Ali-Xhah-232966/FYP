[JSInvokable]
public void HandleScroll(double scrollTop)
{
    if (scrollTop > _lastScrollTop && scrollTop > 100) {
        // Scrolling down, hide header
        _headerHidden = true;
    }
    else if (scrollTop < _lastScrollTop) {
        // Scrolling up, show header
        _headerHidden = false;
    }

    _headerScrolled = scrollTop > 50;
    _lastScrollTop = scrollTop;

    InvokeAsync(StateHasChanged); // Trigger UI update
}
