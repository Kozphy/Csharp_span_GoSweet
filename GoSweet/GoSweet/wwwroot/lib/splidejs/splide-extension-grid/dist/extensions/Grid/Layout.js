import { CLASS_CONTAINER, EVENT_HIDDEN, EVENT_VISIBLE, EventInterface } from '@splidejs/splide';
import { child, pad, queryAll, removeAttribute, setAttribute, style, unit } from '@splidejs/splide/src/js/utils';
import { CLASS_SLIDE_COL, CLASS_SLIDE_ROW } from '../../constants/classes';
/**
 * The subcomponent to layout grids.
 *
 * @since 0.5.0
 *
 * @param Splide      - A Splide instance.
 * @param gridOptions - Initialized grid options.
 * @param Dimension   - A Dimension subcomponent.
 *
 * @return A Layout subcomponent object.
 */
export function Layout(Splide, gridOptions, Dimension) {
    const { on, destroy: destroyEvent } = EventInterface(Splide);
    const { Components, options } = Splide;
    const { resolve } = Components.Direction;
    const { forEach } = Components.Slides;
    /**
     * Initializes the component.
     */
    function mount() {
        layout();
        if (options.slideFocus) {
            on(EVENT_VISIBLE, onVisible);
            on(EVENT_HIDDEN, onHidden);
        }
    }
    /**
     * Destroys the component.
     */
    function destroy() {
        forEach(Slide => {
            const { slide } = Slide;
            toggleTabIndex(slide, false);
            getRowsIn(slide).forEach(cell => {
                removeAttribute(cell, 'style');
            });
            getColsIn(slide).forEach(colSlide => {
                cover(colSlide, true);
                removeAttribute(colSlide, 'style');
            });
        });
        destroyEvent();
    }
    /**
     * Layouts grid elements.
     */
    function layout() {
        forEach(Slide => {
            const { slide } = Slide;
            const [rows, cols] = Dimension.get(Slide.isClone ? Slide.slideIndex : Slide.index);
            layoutRow(rows, slide);
            layoutCol(cols, slide);
            getColsIn(Slide.slide).forEach((colSlide, index) => {
                colSlide.id = `${Slide.slide.id}-col${pad(index + 1)}`;
                if (Splide.options.cover) {
                    cover(colSlide);
                }
            });
        });
    }
    /**
     * Layouts row elements by CSS.
     *
     * @param rows  - A number of rows.
     * @param slide - A slide element.
     */
    function layoutRow(rows, slide) {
        const { row: rowGap } = gridOptions.gap;
        const height = `calc(${100 / rows}%${rowGap ? ` - ${unit(rowGap)} * ${(rows - 1) / rows}` : ''})`;
        getRowsIn(slide).forEach((rowElm, index, rowElms) => {
            style(rowElm, 'height', height);
            style(rowElm, 'display', 'flex');
            style(rowElm, 'margin', `0 0 ${unit(rowGap)} 0`);
            style(rowElm, 'padding', 0);
            if (index === rowElms.length - 1) {
                style(rowElm, 'marginBottom', 0);
            }
        });
    }
    /**
     * Layouts col elements by CSS.
     *
     * @param cols  - A number of cols.
     * @param slide - A slide element.
     */
    function layoutCol(cols, slide) {
        const { col: colGap } = gridOptions.gap;
        const width = `calc(${100 / cols}%${colGap ? ` - ${unit(colGap)} * ${(cols - 1) / cols}` : ''})`;
        getColsIn(slide).forEach((colElm, index, colElms) => {
            style(colElm, 'width', width);
            if (index !== colElms.length - 1) {
                style(colElm, resolve('marginRight'), unit(colGap));
            }
        });
    }
    /**
     * Sets the background image to the col element by its own image element.
     *
     * @param colSlide - A col slide element.
     * @param uncover  - Optional. If `true`, reset the cover mode.
     */
    function cover(colSlide, uncover) {
        const container = child(colSlide, `.${CLASS_CONTAINER}`);
        const img = child(container || colSlide, 'img');
        if (img && img.src) {
            style(container || colSlide, 'background', uncover ? '' : `center/cover no-repeat url("${img.src}")`);
            style(img, 'display', uncover ? '' : 'none');
        }
    }
    /**
     * Returns row elements in the provided slide.
     *
     * @param slide - A slide element.
     *
     * @return An array with row elements.
     */
    function getRowsIn(slide) {
        return queryAll(slide, `.${CLASS_SLIDE_ROW}`);
    }
    /**
     * Returns col elements in the provided slide.
     *
     * @param slide - A slide element.
     *
     * @return An array with col elements.
     */
    function getColsIn(slide) {
        return queryAll(slide, `.${CLASS_SLIDE_COL}`);
    }
    /**
     * Toggles the tab index of col elements.
     *
     * @param slide - A slide element.
     * @param add   - Optional. Determines whether to add or remove tab index.
     */
    function toggleTabIndex(slide, add) {
        getColsIn(slide).forEach(colSlide => {
            setAttribute(colSlide, 'tabindex', add ? 0 : null);
        });
    }
    /**
     * Called when any slide becomes visible.
     *
     * @param Slide - A Slide component.
     */
    function onVisible(Slide) {
        toggleTabIndex(Slide.slide, true);
    }
    /**
     * Called when any slide gets hidden.
     *
     * @param Slide - A Slide component.
     */
    function onHidden(Slide) {
        toggleTabIndex(Slide.slide, false);
    }
    return {
        mount,
        destroy,
    };
}
//# sourceMappingURL=../../../src/js/extensions/Grid/Layout.js.map